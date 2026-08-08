using UnityEngine;
using System.Collections.Generic;
using System;
using AsphaltAnarchy.Echo;
using AsphaltAnarchy.AI;

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

        [Header("Player Node Assault (shares reclaimCheckInterval's tick — no separate timer)")]
        [SerializeField] private float assaultChance = 0.2f; // mirrors reclaimChance's value, independently tunable

        private FactionManager factionManager;
        private EchoSystem echoSystem;
        private EnemyAIManager enemyAIManager;
        private float reclaimTimer;

        public static event Action<TurfNode> OnNodeClaimed;
        public static event Action<TurfNode> OnNodeLost;
        public static event Action<TurfNode> OnDefenseEventTriggered;

        public void Initialize(FactionManager factions, EchoSystem echo)
        {
            factionManager = factions;
            echoSystem = echo;
            enemyAIManager = FindObjectOfType<EnemyAIManager>();

            foreach (var node in allNodes)
            {
                node.Initialize(this, factions);
                if (node.StartingFaction != null)
                {
                    node.SetController(node.StartingFaction);
                }
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
                CheckPlayerNodeAssaults();
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

        /// <summary>
        /// Separate mechanism from CheckReclaims() above, not a shared code path — see
        /// Shared Notes.txt's 2026-08-08 investigation for why: CheckReclaims() targets
        /// non-player nodes gated on WasRecentlyLost (only true after a node has already
        /// changed hands once) and, via TriggerDefenseEvent(), only ever reinforces the
        /// CURRENT controller — it never flips ownership for anyone. A player node that
        /// has never been captured needs to be a valid assault target from the start, and
        /// the attacker here is a hostile OUTSIDE faction, not the current (player) owner.
        /// Deliberately reuses this method's own Update() tick instead of a second timer.
        /// </summary>
        private void CheckPlayerNodeAssaults()
        {
            var playerFaction = factionManager?.PlayerFaction;
            if (playerFaction == null) return;

            foreach (var node in allNodes)
            {
                if (node.ControllingFaction != playerFaction) continue;
                if (node.IsUnderAssault) continue;

                if (UnityEngine.Random.value < assaultChance)
                {
                    var attacker = PickAssaultingFaction();
                    if (attacker != null)
                        node.BeginAssault(attacker);
                }
            }
        }

        private FactionData PickAssaultingFaction()
        {
            var hostile = factionManager?.GetHostileFactions();
            if (hostile == null || hostile.Count == 0) return null;
            return hostile[UnityEngine.Random.Range(0, hostile.Count)];
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

            if (node.ControllingFaction != null && enemyAIManager != null)
            {
                int defenseWaveCount = Mathf.Max(1, node.ControllingFaction.defensiveness > 0.7f ? 4 : 2);
                enemyAIManager.SpawnEnemyWave(node.ControllingFaction, node.transform.position, defenseWaveCount);
            }
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
