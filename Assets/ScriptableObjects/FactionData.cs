using UnityEngine;

namespace AsphaltAnarchy.Factions
{
    /// <summary>
    /// Defines a faction/gang in Queen City '95.
    /// ScriptableObject for designer-friendly faction creation.
    /// </summary>
    [CreateAssetMenu(fileName = "NewFaction", menuName = "Asphalt Anarchy/Faction")]
    public class FactionData : ScriptableObject
    {
        [Header("Identity")]
        public string factionName = "The Neon Saints";
        public string description = "Corporate-backed, high-tech racers.";
        public Color factionColor = Color.cyan;
        public Sprite emblem;

        [Header("Territory")]
        public string primaryTerritory = "Downtown";
        public string secondaryTerritory = "Mount Adams";

        [Header("Style")]
        [TextArea]
        public string combatStyle = "Precision strikes, electrified batons, pack tactics.";
        public GameObject bikePrefab;
        public GameObject riderPrefab;

        [Header("AI Personality")]
        [Range(0f, 1f)]
        public float aggression = 0.7f;
        [Range(0f, 1f)]
        public float coordination = 0.8f;
        [Range(0f, 1f)]
        public float fearThreshold = 0.3f;
        [Range(0f, 1f)]
        public float defensiveness = 0.4f;

        [Header("Relations")]
        [Range(-1f, 1f)]
        public float playerRelation = -0.5f;

        [Header("Echo Response")]
        [TextArea]
        public string echoResponseLow = "Aggressive and confident.";
        [TextArea]
        public string echoResponseMid = "Cautious, begins making mistakes.";
        [TextArea]
        public string echoResponseHigh = "Terrified, may flee or freeze.";
    }
}
