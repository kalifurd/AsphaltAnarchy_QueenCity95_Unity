using UnityEngine;
using System.Collections.Generic;
using System;

namespace AsphaltAnarchy.Factions
{
    /// <summary>
    /// Manages all factions, their territories, and dynamic relations.
    /// </summary>
    public class FactionManager : MonoBehaviour
    {
        [Header("Factions")]
        [SerializeField] private List<FactionData> allFactions;
        [SerializeField] private FactionData playerFaction;

        public FactionData PlayerFaction => playerFaction;

        [Header("Dynamic Relations")]
        [SerializeField] private float relationDecayRate = 0.01f;
        [SerializeField] private float relationImprovementRate = 0.05f;

        private Dictionary<FactionData, float> factionRelations = new Dictionary<FactionData, float>();
        private Dictionary<FactionData, int> factionTerritoryCount = new Dictionary<FactionData, int>();

        public static event Action<FactionData, float> OnRelationChanged;
        public static event Action<FactionData> OnFactionDefeated;

        public void Initialize()
        {
            foreach (var faction in allFactions)
            {
                if (!factionRelations.ContainsKey(faction))
                {
                    factionRelations[faction] = faction.playerRelation;
                    factionTerritoryCount[faction] = 0;
                }
            }
        }

        public float GetRelation(FactionData faction)
        {
            if (factionRelations.TryGetValue(faction, out float relation))
                return relation;
            return 0f;
        }

        public void ModifyRelation(FactionData faction, float delta)
        {
            if (!factionRelations.ContainsKey(faction)) return;

            factionRelations[faction] = Mathf.Clamp(factionRelations[faction] + delta, -1f, 1f);
            OnRelationChanged?.Invoke(faction, factionRelations[faction]);

            // Check for faction defeat
            if (factionRelations[faction] <= -1f && GetTerritoryCount(faction) == 0)
            {
                OnFactionDefeated?.Invoke(faction);
            }
        }

        public void SetTerritoryCount(FactionData faction, int count)
        {
            factionTerritoryCount[faction] = count;
        }

        public int GetTerritoryCount(FactionData faction)
        {
            if (factionTerritoryCount.TryGetValue(faction, out int count))
                return count;
            return 0;
        }

        public FactionData GetFactionByName(string name)
        {
            return allFactions.Find(f => f.factionName == name);
        }

        public List<FactionData> GetAllFactions()
        {
            return new List<FactionData>(allFactions);
        }

        public List<FactionData> GetHostileFactions()
        {
            var hostile = new List<FactionData>();
            foreach (var kvp in factionRelations)
            {
                if (kvp.Value < -0.3f)
                    hostile.Add(kvp.Key);
            }
            return hostile;
        }

        public List<FactionSerializableData> GetSerializableData()
        {
            var data = new List<FactionSerializableData>();
            foreach (var kvp in factionRelations)
            {
                data.Add(new FactionSerializableData
                {
                    factionName = kvp.Key.factionName,
                    relation = kvp.Value,
                    territoryCount = factionTerritoryCount.GetValueOrDefault(kvp.Key, 0)
                });
            }
            return data;
        }

        public void LoadFromSerializableData(List<FactionSerializableData> data)
        {
            foreach (var entry in data)
            {
                var faction = GetFactionByName(entry.factionName);
                if (faction != null)
                {
                    factionRelations[faction] = entry.relation;
                    factionTerritoryCount[faction] = entry.territoryCount;
                }
            }
        }
    }

    [System.Serializable]
    public class FactionSerializableData
    {
        public string factionName;
        public float relation;
        public int territoryCount;
    }
}
