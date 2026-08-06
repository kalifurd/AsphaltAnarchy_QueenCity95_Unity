using UnityEngine;
using System;
using AsphaltAnarchy.Core;
using AsphaltAnarchy.AI;

namespace AsphaltAnarchy.Factions
{
    /// <summary>
    /// Represents a single capturable territory node.
    /// Can be claimed by winning races, surviving combat gauntlets, or completing stunts.
    /// </summary>
    public class TurfNode : MonoBehaviour
    {
        [Header("Identity")]
        [SerializeField] private string nodeName = "OTR Alley";
        [SerializeField] private string description = "A narrow alley in Over-the-Rhine.";
        [SerializeField] private FactionData startingFaction;

        [Header("Capture Requirements")]
        [SerializeField] private CaptureType captureType = CaptureType.Race;
        [SerializeField] private float difficultyRating = 3f; // 1-10
        [SerializeField] private int enemyCount = 5;

        [Header("Rewards")]
        [SerializeField] private int scrapReward = 50;
        [SerializeField] private int tokenReward = 10;
        [SerializeField] private float echoPointsReward = 25f;

        [Header("Visuals")]
        [SerializeField] private Renderer territoryBorder;
        [SerializeField] private Color playerColor = Color.green;
        [SerializeField] private Color enemyColor = Color.red;
        [SerializeField] private Color neutralColor = Color.gray;

        [Header("Safehouse")]
        [SerializeField] private bool hasSafehouse = false;
        [SerializeField] private Transform safehouseSpawnPoint;

        private TurfWarManager turfManager;
        private FactionManager factionManager;
        private FactionData controllingFaction;
        private bool wasRecentlyLost;
        private float timeSinceLost;

        public string NodeName => nodeName;
        public FactionData ControllingFaction => controllingFaction;
        public FactionData StartingFaction => startingFaction;
        public CaptureType CaptureMethod => captureType;
        public float Difficulty => difficultyRating;
        public bool WasRecentlyLost => wasRecentlyLost;
        public bool HasSafehouse => hasSafehouse;

        public static event Action<TurfNode> OnNodeEntered;
        public static event Action<TurfNode> OnNodeExited;

        public void Initialize(TurfWarManager manager, FactionManager factions)
        {
            turfManager = manager;
            factionManager = factions;
            UpdateVisuals();
        }

        public void SetController(FactionData faction)
        {
            if (controllingFaction != null && faction != controllingFaction)
            {
                wasRecentlyLost = true;
                timeSinceLost = Time.time;
            }

            controllingFaction = faction;
            UpdateVisuals();
        }

        private void Update()
        {
            if (wasRecentlyLost && Time.time - timeSinceLost > 300f)
            {
                wasRecentlyLost = false;
            }
        }

        private void UpdateVisuals()
        {
            if (territoryBorder == null) return;

            Color targetColor = neutralColor;
            if (controllingFaction != null)
            {
                var playerFaction = factionManager?.PlayerFaction;
                targetColor = controllingFaction == playerFaction ? playerColor : enemyColor;
            }

            territoryBorder.material.color = targetColor;
        }

        public void StartCaptureChallenge()
        {
            switch (captureType)
            {
                case CaptureType.Race:
                    StartRace();
                    break;
                case CaptureType.CombatGauntlet:
                    StartCombatGauntlet();
                    break;
                case CaptureType.Stunt:
                    StartStuntChallenge();
                    break;
            }
        }

        private void StartRace()
        {
            GameManager.Instance?.ChangeState(GameState.Racing);
            // Race manager handles the actual race logic
            // On completion, call CompleteCapture()
        }

        private void StartCombatGauntlet()
        {
            GameManager.Instance?.ChangeState(GameState.Combat);

            if (controllingFaction != null)
            {
                var enemyAIManager = FindObjectOfType<EnemyAIManager>();
                if (enemyAIManager != null)
                {
                    enemyAIManager.SpawnEnemyWave(controllingFaction, transform.position, enemyCount);
                }
            }
        }

        private void StartStuntChallenge()
        {
            // Stunt jump or drift challenge
            // On completion, call CompleteCapture()
        }

        public void CompleteCapture(bool playerWon)
        {
            if (!playerWon) return;

            var playerFaction = factionManager?.PlayerFaction;
            turfManager?.ClaimNode(this, playerFaction);

            // Award rewards
            var playerStats = FindObjectOfType<PlayerStats>();
            playerStats?.AddScrap(scrapReward);
            playerStats?.AddTokens(tokenReward);

            GameManager.Instance?.ChangeState(GameState.Exploring);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnNodeEntered?.Invoke(this);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnNodeExited?.Invoke(this);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Color gizmoColor = neutralColor;
            if (controllingFaction != null && factionManager != null)
            {
                gizmoColor = factionManager.GetRelation(controllingFaction) > 0 ? Color.green : Color.red;
            }
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, 10f);
        }
    }

    public enum CaptureType
    {
        Race,
        CombatGauntlet,
        Stunt
    }
}
