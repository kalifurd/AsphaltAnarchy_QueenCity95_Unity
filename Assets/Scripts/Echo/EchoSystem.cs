using UnityEngine;
using System;
using System.Collections.Generic;
using AsphaltAnarchy.Core;
using AsphaltAnarchy.AI;
using AsphaltAnarchy.Factions;

namespace AsphaltAnarchy.Echo
{
    /// <summary>
    /// The Echo System: dynamic reputation mechanic where player actions
    /// manifest as supernatural urban legends, altering enemy AI and the environment.
    /// </summary>
    public class EchoSystem : MonoBehaviour
    {
        [Header("Echo Levels")]
        [SerializeField] private int maxLevel = 10;
        [SerializeField] private float pointsPerLevel = 100f;
        [SerializeField] private float currentPoints;
        [SerializeField] private int currentLevel;

        [Header("Psychological Warfare")]
        [SerializeField] private float fearRadius = 50f;
        [SerializeField] private AnimationCurve fearCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [Header("Myth Walk")]
        [SerializeField] private bool mythWalkActive;
        [SerializeField] private float mythWalkDuration = 30f;
        [SerializeField] private float mythWalkCooldown = 120f;

        [Header("Visual Feedback")]
        [SerializeField] private ParticleSystem echoAura;
        [SerializeField] private Light echoLight;
        [SerializeField] private float auraIntensityPerLevel = 0.1f;

        [Header("Echo Tags (Graffiti)")]
        [SerializeField] private List<GameObject> echoTagPrefabs;
        [SerializeField] private Transform graffitiParent;
        [SerializeField] private int tagsPerLevel = 3;

        private PlayerStats playerStats;
        private float mythWalkTimer;
        private float mythWalkCooldownTimer;
        private List<GameObject> spawnedTags = new List<GameObject>();

        public int CurrentLevel => currentLevel;
        public float CurrentPoints => currentPoints;
        public float PointsToNextLevel => pointsPerLevel;
        public float ProgressToNextLevel => currentPoints / pointsPerLevel;
        public bool IsMythWalkActive => mythWalkActive;
        public float FearRadius => fearRadius;
        public float CurrentFearFactor => fearCurve.Evaluate(currentLevel / (float)maxLevel);

        public static event Action<int> OnEchoLevelUp;
        public static event Action<float> OnEchoPointsChanged;
        public static event Action<bool> OnMythWalkToggled;

        public void Initialize(PlayerStats stats)
        {
            playerStats = stats;
            UpdateVisuals();
        }

        public void AddPoints(float amount, EchoSource source)
        {
            float multiplier = source switch
            {
                EchoSource.RaceWin => 1.5f,
                EchoSource.Combat => 1.0f,
                EchoSource.Hijack => 2.0f,
                EchoSource.Stunt => 1.2f,
                EchoSource.TurfClaim => 2.5f,
                EchoSource.Exploration => 0.5f,
                _ => 1.0f
            };

            float finalAmount = amount * multiplier;
            currentPoints += finalAmount;
            OnEchoPointsChanged?.Invoke(currentPoints);

            CheckLevelUp();
        }

        private void CheckLevelUp()
        {
            while (currentPoints >= pointsPerLevel && currentLevel < maxLevel)
            {
                currentPoints -= pointsPerLevel;
                currentLevel++;
                OnEchoLevelUp?.Invoke(currentLevel);
                ApplyLevelEffects(currentLevel);
            }
        }

        private void ApplyLevelEffects(int level)
        {
            UpdateVisuals();
            SpawnEchoTags(level);

            // Unlock Myth Walk at max level
            if (level >= maxLevel)
            {
                playerStats?.UnlockMythWalk();
            }

            // Broadcast to AI systems
            var aiManager = FindObjectOfType<EnemyAIManager>();
            aiManager?.UpdateGlobalFearLevel(level);
        }

        private void UpdateVisuals()
        {
            float intensity = currentLevel * auraIntensityPerLevel;

            if (echoLight != null)
            {
                echoLight.intensity = Mathf.Lerp(0f, 2f, intensity);
            }

            if (echoAura != null)
            {
                var emission = echoAura.emission;
                emission.rateOverTime = new ParticleSystem.MinMaxCurve(currentLevel * 10f);
            }
        }

        private void SpawnEchoTags(int level)
        {
            if (echoTagPrefabs == null || echoTagPrefabs.Count == 0) return;

            // Spawn graffiti in claimed territories
            var turfManager = FindObjectOfType<TurfWarManager>();
            var claimedNodes = turfManager?.GetPlayerClaimedNodes() ?? new List<TurfNode>();

            int tagsToSpawn = Mathf.Min(tagsPerLevel, claimedNodes.Count);
            for (int i = 0; i < tagsToSpawn; i++)
            {
                if (claimedNodes.Count == 0) break;
                var node = claimedNodes[UnityEngine.Random.Range(0, claimedNodes.Count)];
                var prefab = echoTagPrefabs[UnityEngine.Random.Range(0, echoTagPrefabs.Count)];

                Vector3 spawnPos = node.transform.position + UnityEngine.Random.onUnitSphere * 10f;
                spawnPos.y = node.transform.position.y;

                var tag = Instantiate(prefab, spawnPos, Quaternion.identity, graffitiParent);
                spawnedTags.Add(tag);
            }
        }

        public void ToggleMythWalk()
        {
            if (playerStats?.HasMythWalkUnlocked != true) return;
            if (mythWalkCooldownTimer > 0f) return;

            if (!mythWalkActive)
            {
                ActivateMythWalk();
            }
        }

        private void ActivateMythWalk()
        {
            mythWalkActive = true;
            mythWalkTimer = mythWalkDuration;
            OnMythWalkToggled?.Invoke(true);

            // Environment assists
            ApplyMythWalkEffects();
        }

        private void ApplyMythWalkEffects()
        {
            // Traffic lights turn green
            var trafficLights = FindObjectsOfType<TrafficLight>();
            foreach (var light in trafficLights)
            {
                light.ForceGreenForPlayer();
            }

            // Police diverted
            var police = FindObjectsOfType<PoliceUnit>();
            foreach (var unit in police)
            {
                unit.DivertPatrol();
            }

            // Silent convoys emerge
            SpawnSilentConvoy();
        }

        private void SpawnSilentConvoy()
        {
            // Spawn friendly riders that block pursuers
            // Implementation depends on spawn point system
        }

        private void Update()
        {
            if (mythWalkActive)
            {
                mythWalkTimer -= Time.deltaTime;
                if (mythWalkTimer <= 0f)
                {
                    DeactivateMythWalk();
                }
            }

            if (mythWalkCooldownTimer > 0f)
            {
                mythWalkCooldownTimer -= Time.deltaTime;
            }
        }

        private void DeactivateMythWalk()
        {
            mythWalkActive = false;
            mythWalkCooldownTimer = mythWalkCooldown;
            OnMythWalkToggled?.Invoke(false);
        }

        public float GetFearFactorAtDistance(float distance)
        {
            if (distance > fearRadius) return 0f;
            float normalizedDist = 1f - (distance / fearRadius);
            return fearCurve.Evaluate(normalizedDist) * (currentLevel / (float)maxLevel);
        }

        public void LoadData(int level, float points)
        {
            currentLevel = level;
            currentPoints = points;
            UpdateVisuals();
        }
    }

    public enum EchoSource
    {
        RaceWin,
        Combat,
        Hijack,
        Stunt,
        TurfClaim,
        Exploration
    }
}
