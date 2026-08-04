using UnityEngine;
using System.Collections.Generic;
using System;
using AsphaltAnarchy.Echo;

namespace AsphaltAnarchy.Factions
{
    /// <summary>
    /// Manages Turf Nodes, territory claiming, and dynamic defense events.
    /// </summary>
    public class TurfWarManager : MonoBehaviour
    {
        [Header("Turf Nodes")]
        [SerializeField] private List<TurfNode> allNodes = new List<TurfNode>();

        [Header("Reclaim Mechanics")]
        [SerializeField] private float reclaimCheckInterval = 60f;
        [SerializeField] private float reclaimChance = 0.2f;

        private FactionManager factionManager;
        private EchoSystem echoSystem;
        private float reclaimTimer;

        public static event Action<TurfNode> OnNodeClaimed;
        public static event Action<TurfNode> OnNodeLost;
        public static event Action<TurfNode> OnDefenseEventTriggered;

        public void Initialize(FactionManager factions, EchoSystem echo)
        {
            factionManager = factions;
            echoSystem = echo;

            foreach (var node in allNodes)
            {
                node.Initialize(this, factions);
            }

            UpdateFactionTerritoryCounts();
        }

        private void Update()
        {
            reclaimTimer += Time.deltaTime;
            if (reclaimTimer >= reclaimCheckInterval)
            {
                reclaimTimer = 0f;
                CheckReclaims();
            }
        }

        private void CheckReclaims()
        {
            foreach (var node in allNodes)
            {
                if (node.ControllingFaction == null) continue;
                if (node.ControllingFaction == factionManager.PlayerFaction) continue;

                // Factions attempt to reclaim lost nodes
                if (node.WasRecentlyLost && UnityEngine.Random.value < reclaimChance)
                {
                    TriggerDefenseEvent(node);
                }
            }
        }

        public void ClaimNode(TurfNode node, FactionData newFaction)
        {
            FactionData oldFaction = node.ControllingFaction;
            node.SetController(newFaction);

            if (newFaction == factionManager.PlayerFaction)
            {
                OnNodeClaimed?.Invoke(node);
                echoSystem?.AddPoints(100f, EchoSource.TurfClaim);

                // Improve relation with neutral factions, worsen with the one you took from
                if (oldFaction != null)
                {
                    factionManager?.ModifyRelation(oldFaction, -0.2f);
                }
            }
            else if (oldFaction == factionManager.PlayerFaction)
            {
                OnNodeLost?.Invoke(node);
            }

            UpdateFactionTerritoryCounts();
        }

        private void TriggerDefenseEvent(TurfNode node)
        {
            OnDefenseEventTriggered?.Invoke(node);
            // Spawn enemy wave to reclaim
            // Implementation depends on spawn system
        }

        private void UpdateFactionTerritoryCounts()
        {
            var counts = new Dictionary<FactionData, int>();
            foreach (var node in allNodes)
            {
                if (node.ControllingFaction == null) continue;
                if (!counts.ContainsKey(node.ControllingFaction))
                    counts[node.ControllingFaction] = 0;
                counts[node.ControllingFaction]++;
            }

            foreach (var kvp in counts)
            {
                factionManager?.SetTerritoryCount(kvp.Key, kvp.Value);
            }
        }

        public List<TurfNode> GetPlayerClaimedNodes()
        {
            var playerFaction = factionManager?.PlayerFaction;
            var claimed = new List<TurfNode>();
            foreach (var node in allNodes)
            {
                if (node.ControllingFaction == playerFaction)
                    claimed.Add(node);
            }
            return claimed;
        }

        public List<TurfNodeSerializableData> GetSerializableData()
        {
            var data = new List<TurfNodeSerializableData>();
            foreach (var node in allNodes)
            {
                data.Add(new TurfNodeSerializableData
                {
                    nodeName = node.NodeName,
                    controllerFactionName = node.ControllingFaction?.factionName,
                    isPlayerOwned = node.ControllingFaction == factionManager?.PlayerFaction
                });
            }
            return data;
        }

        public void LoadFromSerializableData(List<TurfNodeSerializableData> data)
        {
            foreach (var entry in data)
            {
                var node = allNodes.Find(n => n.NodeName == entry.nodeName);
                if (node != null)
                {
                    var faction = factionManager?.GetFactionByName(entry.controllerFactionName);
                    node.SetController(faction);
                }
            }
            UpdateFactionTerritoryCounts();
        }
    }

    [System.Serializable]
    public class TurfNodeSerializableData
    {
        public string nodeName;
        public string controllerFactionName;
        public bool isPlayerOwned;
    }
}
