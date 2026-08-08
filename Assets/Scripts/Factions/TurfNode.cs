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

        [Header("Passive Assault (undefended enemy capture)")]
        [SerializeField] private float assaultGracePeriod = 30f; // placeholder default, not doc-specified — real window to notice/respond, tunable

        private TurfWarManager turfManager;
        private FactionManager factionManager;
        private FactionData controllingFaction;
        private bool wasRecentlyLost;
        private float timeSinceLost;
        private bool isUnderAssault;
        private FactionData assaultingFaction;
        private float assaultStartTime;

        public string NodeName => nodeName;
        public FactionData ControllingFaction => controllingFaction;
        public FactionData StartingFaction => startingFaction;
        public CaptureType CaptureMethod => captureType;
        public float Difficulty => difficultyRating;
        public bool WasRecentlyLost => wasRecentlyLost;
        public bool HasSafehouse => hasSafehouse;
        public bool IsUnderAssault => isUnderAssault;
        public FactionData AssaultingFaction => assaultingFaction;
        public float AssaultTimeRemaining => isUnderAssault ? Mathf.Max(0f, assaultGracePeriod - (Time.time - assaultStartTime)) : 0f;

        public static event Action<TurfNode> OnNodeEntered;
        public static event Action<TurfNode> OnNodeExited;
        public static event Action<TurfNode> OnNodeAssaultStarted;
        public static event Action<TurfNode> OnNodeAssaultResolved;

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

            if (isUnderAssault && Time.time - assaultStartTime >= assaultGracePeriod)
            {
                ResolveAssault();
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
                    int count = enemyCount;

                    bool finiteManpower = factionManager != null && factionManager.HasFiniteManpower(controllingFaction);
                    if (finiteManpower)
                    {
                        int available = factionManager.GetManpower(controllingFaction);
                        count = Mathf.Min(count, available);
                        if (count <= 0) return; // faction's roster is tapped out - no gauntlet

                        factionManager.ConsumeManpower(controllingFaction, count);
                    }

                    enemyAIManager.SpawnEnemyWave(controllingFaction, transform.position, count);
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

        /// <summary>
        /// Starts the undefended-passive-capture grace period for a PlayerCrew-owned
        /// node under assault by a hostile faction. Does not resolve immediately —
        /// see ResolveAssault(), called from Update() once assaultGracePeriod elapses.
        /// Deliberately independent of PlayerStats.OnPlayerDied/GameState.GameOver.
        /// </summary>
        public void BeginAssault(FactionData attacker)
        {
            if (isUnderAssault || attacker == null) return;

            isUnderAssault = true;
            assaultingFaction = attacker;
            assaultStartTime = Time.time;
            OnNodeAssaultStarted?.Invoke(this);
        }

        /// <summary>
        /// Sibling to CompleteCapture(bool playerWon), for the enemy-wins case.
        /// Reuses TurfWarManager.ClaimNode() unchanged — it's already faction-agnostic.
        /// </summary>
        public void CompleteEnemyCapture(FactionData attackingFaction)
        {
            if (attackingFaction == null) return;
            turfManager?.ClaimNode(this, attackingFaction);
        }

        private void ResolveAssault()
        {
            var attacker = assaultingFaction;
            isUnderAssault = false;
            assaultingFaction = null;

            // Defensive check: if something else already moved this node off the
            // player (not possible via any path that exists today, but cheap to guard).
            if (controllingFaction == factionManager?.PlayerFaction)
            {
                CompleteEnemyCapture(attacker);
            }

            OnNodeAssaultResolved?.Invoke(this);
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
