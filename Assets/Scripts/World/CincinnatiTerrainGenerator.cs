using UnityEngine;

namespace AsphaltAnarchy.World
{
    /// <summary>
    /// Procedurally generates a Unity Terrain loosely modeling the topography of the
    /// Greater Cincinnati metro area: a broad river valley (the Ohio River) with steep
    /// walls cutting through a rolling upland, rougher/more dissected hills on the
    /// unglaciated south/east side (Northern Kentucky, eastern Clermont County), and
    /// gentler, smoother rolling hills on the glaciated north/west side (Butler/Warren
    /// counties, Till Plains). Not survey-accurate — a stylized approximation for a
    /// level or prototype.
    ///
    /// Setup:
    ///  1. Create an empty GameObject in your scene.
    ///  2. Add this script to it.
    ///  3. Adjust the public fields in the Inspector as desired.
    ///  4. Right-click the component header (or use the gear menu) and choose
    ///     "Generate Terrain", or just press Play if generateOnStart is checked.
    ///
    /// The script creates its own Terrain object as a child (or reuses one it
    /// previously created), so it's safe to tweak values and regenerate repeatedly.
    /// </summary>
    [ExecuteInEditMode]
    public class CincinnatiTerrainGenerator : MonoBehaviour
    {
        [Header("Terrain Size")]
        [Tooltip("Heightmap resolution. Must be (power of two) + 1, e.g. 129, 257, 513, 1025.")]
        public int heightmapResolution = 513;

        [Tooltip("Width and length of the terrain in world units (meters).")]
        public Vector2 terrainSize = new Vector2(2000f, 2000f);

        [Tooltip("Maximum vertical relief in world units (meters). Real Cincinnati relief " +
                 "is roughly 400-550 feet (~120-170m) from riverbank to the highest ridges.")]
        public float terrainHeight = 150f;

        [Header("Random Seed")]
        public int seed = 12345;
        public bool randomizeSeedOnGenerate = false;

        [Header("Base Rolling-Hills Noise")]
        [Tooltip("Number of layered noise octaves for the base hills.")]
        [Range(1, 8)] public int octaves = 5;
        [Tooltip("How much each octave's amplitude shrinks relative to the previous one.")]
        [Range(0f, 1f)] public float persistence = 0.5f;
        [Tooltip("How much each octave's frequency grows relative to the previous one.")]
        public float lacunarity = 2f;
        [Tooltip("Base noise scale. Smaller = broader, larger = choppier hills.")]
        public float baseNoiseScale = 6f;

        [Header("North/West vs South/East Character")]
        [Tooltip("0 = smooth glaciated till-plain roughness, 1 = rugged unglaciated roughness. " +
                 "The generator blends between these across the map based on riverAxis.")]
        [Range(0f, 1f)] public float glaciatedRoughness = 0.25f;
        [Range(0f, 1f)] public float unglaciatedRoughness = 0.9f;
        [Tooltip("Extra fine-detail noise frequency multiplier used to roughen the unglaciated side.")]
        public float detailNoiseFrequency = 4f;

        [Header("River Valley (Ohio River)")]
        [Tooltip("0 = river runs along X (east-west), 1 = river runs along Z (north-south).")]
        [Range(0f, 1f)] public float riverAxis = 0f;
        [Tooltip("Position of the river centerline across the terrain, 0-1 (0.5 = middle).")]
        [Range(0f, 1f)] public float riverPosition = 0.5f;
        [Tooltip("How much the river meanders side to side, as a fraction of terrain size.")]
        [Range(0f, 0.3f)] public float riverMeander = 0.08f;
        [Tooltip("Number of meander bends along the river's length.")]
        public float riverMeanderFrequency = 2.5f;
        [Tooltip("Half-width of the flat river channel itself, as a fraction of terrain size.")]
        [Range(0.01f, 0.15f)] public float riverChannelWidth = 0.03f;
        [Tooltip("Half-width of the sloped valley walls beyond the channel, as a fraction of terrain size.")]
        [Range(0.02f, 0.4f)] public float riverValleyWidth = 0.12f;
        [Tooltip("How deep the valley cuts, as a fraction of terrainHeight.")]
        [Range(0f, 1f)] public float riverValleyDepth = 0.85f;

        [Header("Exposed Bedrock Terracing")]
        [Tooltip("Adds subtle stepped 'benches' on steeper slopes, evoking exposed limestone/shale layers.")]
        public bool enableTerracing = true;
        [Tooltip("Number of terrace steps applied across the full height range.")]
        [Range(2, 24)] public int terraceSteps = 10;
        [Tooltip("How strongly terracing is blended in (0 = off, 1 = fully stepped).")]
        [Range(0f, 1f)] public float terraceStrength = 0.25f;

        [Header("Behavior")]
        public bool generateOnStart = false;

        Terrain _terrain;
        TerrainData _terrainData;

        void Start()
        {
            if (generateOnStart && Application.isPlaying)
            {
                Generate();
            }
        }

        [ContextMenu("Generate Terrain")]
        public void Generate()
        {
            if (randomizeSeedOnGenerate)
            {
                seed = Random.Range(int.MinValue, int.MaxValue);
            }

            EnsureTerrain();

            int res = Mathf.ClosestPowerOfTwo(heightmapResolution - 1) + 1;
            if (res != heightmapResolution)
            {
                Debug.LogWarning($"CincinnatiTerrainGenerator: heightmapResolution adjusted to {res} " +
                                  "(must be a power of two plus one).");
            }

            _terrainData.heightmapResolution = res;
            _terrainData.size = new Vector3(terrainSize.x, terrainHeight, terrainSize.y);

            float[,] heights = new float[res, res];

            System.Random rng = new System.Random(seed);
            Vector2 offset = new Vector2((float)rng.NextDouble() * 10000f, (float)rng.NextDouble() * 10000f);

            for (int z = 0; z < res; z++)
            {
                for (int x = 0; x < res; x++)
                {
                    float u = (float)x / (res - 1); // 0..1 across width
                    float v = (float)z / (res - 1); // 0..1 across length

                    heights[z, x] = ComputeHeight(u, v, offset);
                }
            }

            _terrainData.SetHeights(0, 0, heights);
        }

        float ComputeHeight(float u, float v, Vector2 offset)
        {
            // Position along the river's running axis (0..1) and across it (0..1),
            // depending on whether the river runs along X or Z.
            float along = Mathf.Lerp(u, v, riverAxis);
            float across = Mathf.Lerp(v, u, riverAxis);

            // Meandering river centerline as a function of position along its length.
            float meanderOffset = Mathf.Sin(along * riverMeanderFrequency * Mathf.PI * 2f) * riverMeander;
            float riverCenter = riverPosition + meanderOffset;
            float distFromRiver = Mathf.Abs(across - riverCenter);

            // Roughness blend: which side of the river are we on?
            // "South/east" (unglaciated, rugged) = across > riverCenter; "north/west" (glaciated, smooth) = across < riverCenter.
            float sideBlend = Mathf.InverseLerp(-0.3f, 0.3f, across - riverCenter);
            float roughness = Mathf.Lerp(glaciatedRoughness, unglaciatedRoughness, sideBlend);

            // Base fractal Brownian motion for rolling hills.
            float amplitude = 1f;
            float frequency = baseNoiseScale;
            float noiseSum = 0f;
            float amplitudeSum = 0f;

            for (int i = 0; i < octaves; i++)
            {
                float nx = (u * frequency) + offset.x;
                float nz = (v * frequency) + offset.y;
                noiseSum += Mathf.PerlinNoise(nx, nz) * amplitude;
                amplitudeSum += amplitude;

                amplitude *= persistence;
                frequency *= lacunarity;
            }
            float baseNoise = noiseSum / Mathf.Max(amplitudeSum, 0.0001f);

            // Extra fine detail, weighted by roughness, to make the unglaciated side choppier.
            float detailNoise = Mathf.PerlinNoise(
                u * baseNoiseScale * detailNoiseFrequency + offset.x * 1.7f,
                v * baseNoiseScale * detailNoiseFrequency + offset.y * 1.7f);
            float height01 = Mathf.Lerp(baseNoise, Mathf.Lerp(baseNoise, detailNoise, 0.5f), roughness);

            // Carve the river valley.
            float channelInner = riverChannelWidth;
            float valleyOuter = riverChannelWidth + riverValleyWidth;

            float valleyFactor; // 0 = fully carved down to channel floor, 1 = untouched upland
            if (distFromRiver <= channelInner)
            {
                valleyFactor = 0f;
            }
            else if (distFromRiver >= valleyOuter)
            {
                valleyFactor = 1f;
            }
            else
            {
                float t = Mathf.InverseLerp(channelInner, valleyOuter, distFromRiver);
                // Smoothstep for a natural-looking valley wall slope.
                valleyFactor = t * t * (3f - 2f * t);
            }

            float channelFloor01 = (1f - riverValleyDepth) * 0.15f; // near the bottom of the height range
            float carvedHeight01 = Mathf.Lerp(channelFloor01, height01, valleyFactor);

            // Optional bedrock terracing on the slopes.
            if (enableTerracing && terraceStrength > 0f)
            {
                float stepped = Mathf.Round(carvedHeight01 * terraceSteps) / terraceSteps;
                carvedHeight01 = Mathf.Lerp(carvedHeight01, stepped, terraceStrength);
            }

            return Mathf.Clamp01(carvedHeight01);
        }

        void EnsureTerrain()
        {
            if (_terrain == null)
            {
                _terrain = GetComponentInChildren<Terrain>();
            }

            if (_terrain == null)
            {
                _terrainData = new TerrainData();
                _terrainData.name = "CincinnatiTerrainData";
                GameObject terrainGO = Terrain.CreateTerrainGameObject(_terrainData);
                terrainGO.name = "CincinnatiTerrain";
                terrainGO.transform.SetParent(transform, false);
                terrainGO.transform.localPosition = new Vector3(-terrainSize.x / 2f, 0f, -terrainSize.y / 2f);
                _terrain = terrainGO.GetComponent<Terrain>();
            }
            else
            {
                _terrainData = _terrain.terrainData;
            }
        }
    }
}
