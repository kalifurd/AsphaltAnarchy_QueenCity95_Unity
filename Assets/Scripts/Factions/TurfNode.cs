using UnityEngine;
using System;
using System.Collections.Generic;
using AsphaltAnarchy.Core;
using AsphaltAnarchy.AI;
using AsphaltAnarchy.Combat;

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
        private readonly List<EnemyHealth> assaultWaveEnemies = new List<EnemyHealth>();

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

        private void OnEnable()
        {
            EnemyHealth.OnEnemyDied += HandleAssaultEnemyDied;
        }

        private void OnDisable()
        {
            EnemyHealth.OnEnemyDied -= HandleAssaultEnemyDied;
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
        /// Starts the grace period for a PlayerCrew-owned node under assault by a
        /// hostile faction, and spawns that faction's wave for the player to fight
        /// off (see SpawnAssaultWave()). Does not resolve immediately — either
        /// DefendAssault() (all spawned enemies defeated in time, via
        /// HandleAssaultEnemyDied()) or ResolveAssault() (grace period elapses
        /// first, called from Update()) ends it. Deliberately independent of
        /// PlayerStats.OnPlayerDied/GameState.GameOver.
        /// </summary>
        public void BeginAssault(FactionData attacker)
        {
            if (isUnderAssault || attacker == null) return;

            isUnderAssault = true;
            assaultingFaction = attacker;
            assaultStartTime = Time.time;
            SpawnAssaultWave(attacker);
            OnNodeAssaultStarted?.Invoke(this);
        }

        /// <summary>
        /// Sibling to StartCombatGauntlet(), spawning the ATTACKING faction's wave
        /// instead of controllingFaction's — same SpawnEnemyWave/manpower-gating
        /// shape, just inverted, per the planning pass's confirmed reuse. Populates
        /// assaultWaveEnemies so HandleAssaultEnemyDied() can detect a successful
        /// defense. If the attacker has finite manpower and none is available, no
        /// wave spawns and the assault still resolves via the existing undefended
        /// timer — same silent-no-op shape StartCombatGauntlet() already has.
        /// </summary>
        private void SpawnAssaultWave(FactionData attacker)
        {
            assaultWaveEnemies.Clear();

            var enemyAIManager = FindObjectOfType<EnemyAIManager>();
            if (enemyAIManager == null) return;

            int count = enemyCount;

            bool finiteManpower = factionManager != null && factionManager.HasFiniteManpower(attacker);
            if (finiteManpower)
            {
                int available = factionManager.GetManpower(attacker);
                count = Mathf.Min(count, available);
                if (count <= 0) return; // attacker's roster is tapped out - no wave

                factionManager.ConsumeManpower(attacker, count);
            }

            var spawned = enemyAIManager.SpawnEnemyWave(attacker, transform.position, count);
            foreach (var enemyAI in spawned)
            {
                var health = enemyAI != null ? enemyAI.GetComponent<EnemyHealth>() : null;
                if (health != null) assaultWaveEnemies.Add(health);
            }
        }

        /// <summary>
        /// Subscribed to EnemyHealth.OnEnemyDied (static, fires for every enemy
        /// death game-wide) — filters down to just this node's assault wave via
        /// assaultWaveEnemies. When the last one dies before the grace period
        /// expires, the defense succeeded.
        /// </summary>
        private void HandleAssaultEnemyDied(EnemyHealth enemy)
        {
            if (!isUnderAssault) return;
            if (assaultWaveEnemies.Remove(enemy) && assaultWaveEnemies.Count == 0)
            {
                DefendAssault();
            }
        }

        /// <summary>
        /// Win path, sibling to ResolveAssault()'s loss path. The node stays with
        /// its current controller — no ClaimNode() call, unlike ResolveAssault().
        /// </summary>
        private void DefendAssault()
        {
            if (!isUnderAssault) return;

            isUnderAssault = false;
            assaultingFaction = null;
            assaultWaveEnemies.Clear();

            OnNodeAssaultResolved?.Invoke(this);
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
            assaultWaveEnemies.Clear();

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
