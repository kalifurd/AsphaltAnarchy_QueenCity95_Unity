using UnityEngine;
using System;
using AsphaltAnarchy.AI;
using AsphaltAnarchy.Combat;
using AsphaltAnarchy.Factions;

namespace AsphaltAnarchy.Heat
{
    /// <summary>
    /// Per-encounter Heat: rises from combat hits and hostile-turf incursions,
    /// triggers capped enemy reinforcement waves past a threshold, and clears
    /// once every pursuer loses line of sight for the countdown duration.
    /// Separate from EchoSystem, which tracks persistent long-term reputation
    /// on a much slower timescale.
    /// </summary>
    public class HeatSystem : MonoBehaviour
    {
        [Header("Heat Gain")]
        [SerializeField] private float maxHeat = 100f;
        [SerializeField] private float heatPerHit = 8f;
        [SerializeField] private float heatPerTurfIncursion = 15f;

        [Header("Wave Spawning")]
        [SerializeField] private float waveThreshold = 60f;
        [SerializeField] private float waveRetriggerCooldown = 20f;
        [SerializeField] private int enemiesPerWave = 2;
        [SerializeField] private int maxWavesPerEncounter = 3;

        [Header("Cooldown / Evasion")]
        [SerializeField] private float loseHeatCountdown = 8f;

        [Header("References")]
        [SerializeField] private EnemyAIManager enemyAIManager;
        [SerializeField] private FactionManager factionManager;

        private float currentHeat;
        private int wavesTriggeredThisEncounter;
        private float waveRetriggerTimer;
        private FactionData encounterFaction;
        private Transform playerTransform;
        private bool isEvading;
        private float evadeTimer;

        public float CurrentHeat => currentHeat;
        public float MaxHeat => maxHeat;
        public float HeatFraction => maxHeat <= 0f ? 0f : Mathf.Clamp01(currentHeat / maxHeat);
        public bool IsEvading => isEvading;
        public float EvadeFraction => loseHeatCountdown <= 0f ? 0f : Mathf.Clamp01(evadeTimer / loseHeatCountdown);
        public int WavesTriggeredThisEncounter => wavesTriggeredThisEncounter;
        public FactionData EncounterFaction => encounterFaction;

        public static event Action<float> OnHeatChanged;
        public static event Action OnWaveTriggered;
        public static event Action OnHeatCleared;

        private void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerTransform = player.transform;

            if (enemyAIManager == null)
                enemyAIManager = FindObjectOfType<EnemyAIManager>();
            if (factionManager == null)
                factionManager = FindObjectOfType<FactionManager>();
        }

        private void OnEnable()
        {
            EnemyHealth.OnDamageTaken += HandleEnemyDamaged;
            TurfNode.OnNodeEntered += HandleTurfEntered;
        }

        private void OnDisable()
        {
            EnemyHealth.OnDamageTaken -= HandleEnemyDamaged;
            TurfNode.OnNodeEntered -= HandleTurfEntered;
        }

        private void Update()
        {
            if (waveRetriggerTimer > 0f)
                waveRetriggerTimer -= Time.deltaTime;

            if (currentHeat <= 0f) return;

            if (AnyPursuerHasLineOfSight())
            {
                isEvading = false;
                evadeTimer = 0f;
            }
            else
            {
                isEvading = true;
                evadeTimer += Time.deltaTime;

                if (evadeTimer >= loseHeatCountdown)
                {
                    ClearHeat();
                }
            }
        }

        private void HandleEnemyDamaged(EnemyHealth enemy, float amount)
        {
            var ai = enemy.GetComponent<EnemyAI>();
            if (ai != null && ai.Faction != null)
                encounterFaction = ai.Faction;

            AddHeat(heatPerHit);
        }

        private void HandleTurfEntered(TurfNode node)
        {
            var controller = node.ControllingFaction;
            if (controller == null) return;
            if (factionManager != null && controller == factionManager.PlayerFaction) return;

            encounterFaction = controller;
            AddHeat(heatPerTurfIncursion);
        }

        public void AddHeat(float amount)
        {
            if (amount <= 0f) return;

            currentHeat = Mathf.Clamp(currentHeat + amount, 0f, maxHeat);
            isEvading = false;
            evadeTimer = 0f;
            OnHeatChanged?.Invoke(currentHeat);

            TryTriggerWave();
        }

        private bool AnyPursuerHasLineOfSight()
        {
            if (enemyAIManager == null) return false;

            var enemies = enemyAIManager.GetActiveEnemies();
            foreach (var enemy in enemies)
            {
                if (enemy == null) continue;
                if (enemy.IsPursuing && enemy.CanSeePlayer())
                    return true;
            }
            return false;
        }

        private void TryTriggerWave()
        {
            if (currentHeat < waveThreshold) return;
            if (wavesTriggeredThisEncounter >= maxWavesPerEncounter) return;
            if (waveRetriggerTimer > 0f) return;

            SpawnReinforcementWave();
        }

        private void SpawnReinforcementWave()
        {
            if (enemyAIManager == null || playerTransform == null) return;

            int count = enemiesPerWave;

            bool finiteManpower = factionManager != null && factionManager.HasFiniteManpower(encounterFaction);
            if (finiteManpower)
            {
                int available = factionManager.GetManpower(encounterFaction);
                count = Mathf.Min(count, available);
                if (count <= 0) return; // faction's roster is tapped out - no wave

                factionManager.ConsumeManpower(encounterFaction, count);
            }

            enemyAIManager.SpawnEnemyWave(encounterFaction, playerTransform.position, count);

            wavesTriggeredThisEncounter++;
            waveRetriggerTimer = waveRetriggerCooldown;
            OnWaveTriggered?.Invoke();
        }

        private void ClearHeat()
        {
            currentHeat = 0f;
            isEvading = false;
            evadeTimer = 0f;
            wavesTriggeredThisEncounter = 0;
            encounterFaction = null;

            OnHeatChanged?.Invoke(currentHeat);
            OnHeatCleared?.Invoke();
        }
    }
}
