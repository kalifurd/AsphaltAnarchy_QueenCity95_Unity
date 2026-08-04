using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AsphaltAnarchy.Vehicle;
using AsphaltAnarchy.Combat;
using AsphaltAnarchy.Echo;
using AsphaltAnarchy.Factions;

namespace AsphaltAnarchy.AI
{
    /// <summary>
    /// Enemy rider AI with dynamic behavior affected by the Echo System.
    /// Implements pack tactics, psychological states, and faction-specific combat styles.
    /// </summary>
    [RequireComponent(typeof(MotorcycleController))]
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyAI : MonoBehaviour
    {
        [Header("AI Personality")]
        [SerializeField] private FactionData faction;
        [SerializeField] private AIState currentState = AIState.Patrol;
        [SerializeField] private AIBehaviorType behaviorType = AIBehaviorType.Aggressive;

        [Header("Detection")]
        [SerializeField] private float detectionRange = 40f;
        [SerializeField] private float attackRange = 5f;
        [SerializeField] private float loseInterestRange = 80f;
        [SerializeField] private LayerMask playerLayer;

        [Header("Combat")]
        [SerializeField] private float attackCooldown = 1.5f;
        [SerializeField] private float preferredCombatSpeed = 20f; // m/s
        [SerializeField] private float fleeSpeed = 25f;

        [Header("Pack Tactics")]
        [SerializeField] private bool isPackLeader = false;
        [SerializeField] private List<EnemyAI> packMembers = new List<EnemyAI>();

        private MotorcycleController bikeController;
        private EnemyHealth health;
        private WeaponManager weaponManager;
        private Transform playerTransform;
        private EchoSystem echoSystem;

        private float currentFearLevel;
        private float lastAttackTime;
        private float stateTimer;
        private bool isGrabbed;
        private Transform grabber;
        private Vector3 patrolCenter;
        private Vector3 patrolTarget;

        public FactionData Faction => faction;
        public AIState CurrentState => currentState;
        public bool IsPackLeader => isPackLeader;

        private void Start()
        {
            bikeController = GetComponent<MotorcycleController>();
            health = GetComponent<EnemyHealth>();
            weaponManager = GetComponent<WeaponManager>();
            patrolCenter = transform.position;
            patrolTarget = GetRandomPatrolPoint();

            echoSystem = FindObjectOfType<EchoSystem>();
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerTransform = player.transform;
        }

        private void Update()
        {
            if (health.IsDismounted || health.IsDead) return;
            if (isGrabbed) return;

            UpdateFearLevel();
            UpdateState();
            ExecuteState();
        }

        private void UpdateFearLevel()
        {
            if (echoSystem == null || playerTransform == null) return;

            float distance = Vector3.Distance(transform.position, playerTransform.position);
            currentFearLevel = echoSystem.GetFearFactorAtDistance(distance);

            // Faction-specific fear threshold
            if (faction != null && currentFearLevel > faction.fearThreshold)
            {
                // High fear overrides behavior
            }
        }

        private void UpdateState()
        {
            if (playerTransform == null) return;

            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            bool canSeePlayer = CanSeePlayer();

            // Echo-driven state transitions
            if (currentFearLevel > 0.8f && faction != null && currentFearLevel > faction.fearThreshold)
            {
                // Terrified - flee or freeze
                if (Random.value < 0.5f)
                    ChangeState(AIState.Flee);
                else
                    ChangeState(AIState.Frozen);
                return;
            }
            else if (currentFearLevel > 0.5f && faction != null && currentFearLevel > faction.fearThreshold)
            {
                // Hesitant - make mistakes
                ChangeState(AIState.Hesitant);
                return;
            }

            switch (currentState)
            {
                case AIState.Patrol:
                    if (distanceToPlayer < detectionRange && canSeePlayer)
                        ChangeState(AIState.Chase);
                    break;

                case AIState.Chase:
                    if (distanceToPlayer > loseInterestRange)
                        ChangeState(AIState.Patrol);
                    else if (distanceToPlayer < attackRange)
                        ChangeState(AIState.Attack);
                    break;

                case AIState.Attack:
                    if (distanceToPlayer > attackRange * 1.5f)
                        ChangeState(AIState.Chase);
                    else if (health.CurrentHealth / health.MaxHealth < 0.3f && faction?.defensiveness > 0.5f)
                        ChangeState(AIState.Flee);
                    break;

                case AIState.Flee:
                    if (distanceToPlayer > loseInterestRange * 0.7f)
                        ChangeState(AIState.Patrol);
                    break;

                case AIState.Frozen:
                    if (currentFearLevel < 0.3f)
                        ChangeState(AIState.Chase);
                    break;

                case AIState.Hesitant:
                    if (currentFearLevel < 0.3f)
                        ChangeState(AIState.Attack);
                    break;
            }
        }

        private void ExecuteState()
        {
            switch (currentState)
            {
                case AIState.Patrol:
                    ExecutePatrol();
                    break;
                case AIState.Chase:
                    ExecuteChase();
                    break;
                case AIState.Attack:
                    ExecuteAttack();
                    break;
                case AIState.Flee:
                    ExecuteFlee();
                    break;
                case AIState.Frozen:
                    ExecuteFrozen();
                    break;
                case AIState.Hesitant:
                    ExecuteHesitant();
                    break;
            }
        }

        private void ExecutePatrol()
        {
            Vector3 toTarget = patrolTarget - transform.position;
            toTarget.y = 0f;

            if (toTarget.magnitude < 5f)
            {
                patrolTarget = GetRandomPatrolPoint();
            }

            SteerToward(patrolTarget, 0.3f);
        }

        private void ExecuteChase()
        {
            if (playerTransform == null) return;

            // Pack coordination
            if (isPackLeader && packMembers.Count > 0)
            {
                // Coordinate flanking
                Vector3 flankOffset = GetFlankPosition();
                SteerToward(playerTransform.position + flankOffset, 0.8f);
            }
            else
            {
                SteerToward(playerTransform.position, 0.8f);
            }
        }

        private void ExecuteAttack()
        {
            if (playerTransform == null) return;

            // Faction-specific combat
            switch (faction?.factionName)
            {
                case "The Neon Saints":
                    ExecutePrecisionStrike();
                    break;
                case "The Rust Barons":
                    ExecuteRamming();
                    break;
                case "The OTR Syndicate":
                    ExecuteHitAndRun();
                    break;
                case "The Kentucky Kings":
                    ExecuteHighSpeedDraft();
                    break;
                case "The Phantoms":
                    ExecutePhantomTactics();
                    break;
                default:
                    ExecuteStandardAttack();
                    break;
            }
        }

        private void ExecuteStandardAttack()
        {
            if (playerTransform == null) return;

            // Match speed and attempt melee
            Vector3 toPlayer = playerTransform.position - transform.position;
            float distance = toPlayer.magnitude;

            if (distance > 3f)
            {
                SteerToward(playerTransform.position, 0.6f);
            }
            else
            {
                // Side-by-side combat
                Vector3 sideDir = Vector3.Cross(Vector3.up, toPlayer.normalized);
                SteerToward(transform.position + sideDir * 5f, 0.4f);
            }

            // Attempt swing
            if (Time.time > lastAttackTime + attackCooldown && weaponManager?.CanSwing == true)
            {
                weaponManager.PerformSwing();
                lastAttackTime = Time.time;
            }
        }

        private void ExecutePrecisionStrike()
        {
            // Neon Saints: Coordinated pack attacks with electrified batons
            if (packMembers.Count >= 2)
            {
                // Surround player
                Vector3 surroundPos = GetSurroundPosition();
                SteerToward(surroundPos, 0.7f);
            }
            else
            {
                ExecuteStandardAttack();
            }
        }

        private void ExecuteRamming()
        {
            // Rust Barons: Heavy ramming attacks
            if (playerTransform == null) return;
            SteerToward(playerTransform.position, 1.0f); // Full throttle ram
        }

        private void ExecuteHitAndRun()
        {
            // OTR Syndicate: Quick attacks then retreat into alleys
            if (stateTimer < 2f)
            {
                SteerToward(playerTransform.position, 0.9f);
                if (weaponManager?.CanSwing == true)
                {
                    weaponManager.PerformSwing();
                }
            }
            else
            {
                // Retreat
                Vector3 retreatDir = -(playerTransform.position - transform.position).normalized;
                SteerToward(transform.position + retreatDir * 50f, 0.8f);
                if (stateTimer > 5f) stateTimer = 0f;
            }
            stateTimer += Time.deltaTime;
        }

        private void ExecuteHighSpeedDraft()
        {
            // Kentucky Kings: High-speed drafting and sideswiping
            if (playerTransform == null) return;
            Vector3 toPlayer = playerTransform.position - transform.position;
            SteerToward(playerTransform.position, 1.0f);

            // Sideswipe when alongside
            if (Mathf.Abs(toPlayer.x) < 2f && toPlayer.z < 5f)
            {
                bikeController.ApplyExternalForce(transform.right * 200f, ForceMode.Force);
            }
        }

        private void ExecutePhantomTactics()
        {
            // Phantoms: Unpredictable, psychological intimidation
            // Erratic movement, fake retreats, sudden attacks
            float phase = Mathf.Sin(Time.time * 2f);
            Vector3 offset = transform.right * phase * 10f;
            SteerToward(playerTransform.position + offset, 0.6f + phase * 0.3f);
        }

        private void ExecuteFlee()
        {
            if (playerTransform == null) return;
            Vector3 fleeDir = (transform.position - playerTransform.position).normalized;
            Vector3 fleeTarget = transform.position + fleeDir * 100f;
            SteerToward(fleeTarget, 1.0f);
        }

        private void ExecuteFrozen()
        {
            // Paralyzed by fear - minimal movement, shaking
            bikeController.ApplyExternalForce(Vector3.zero, ForceMode.Force);
            // Slight tremble
            bikeController.ApplyExternalTorque(Random.insideUnitSphere * 5f, ForceMode.Force);
        }

        private void ExecuteHesitant()
        {
            // Make mistakes: oversteer, slow reactions, random braking
            if (playerTransform == null) return;

            float mistakeChance = 0.3f;
            if (Random.value < mistakeChance * Time.deltaTime)
            {
                // Oversteer mistake
                bikeController.ApplyExternalTorque(transform.up * Random.Range(-100f, 100f), ForceMode.Force);
            }

            // Hesitant approach
            SteerToward(playerTransform.position, 0.3f);
        }

        private void SteerToward(Vector3 target, float throttle)
        {
            Vector3 toTarget = target - transform.position;
            toTarget.y = 0f;

            float steer = Vector3.SignedAngle(transform.forward, toTarget.normalized, Vector3.up) / bikeController.MaxSteerAngle;
            steer = Mathf.Clamp(steer, -1f, 1f);

            // Apply to bike controller via input simulation
            // In a real implementation, this would interface with the controller's input system
            // For now, we apply forces directly
            bikeController.ApplyExternalTorque(Vector3.up * steer * 100f, ForceMode.Force);
            bikeController.ApplyExternalForce(transform.forward * throttle * 500f, ForceMode.Force);
        }

        private bool CanSeePlayer()
        {
            if (playerTransform == null) return false;
            Vector3 toPlayer = playerTransform.position - transform.position;
            if (toPlayer.magnitude > detectionRange) return false;

            // Simple line of sight check
            if (Physics.Raycast(transform.position + Vector3.up, toPlayer.normalized, out RaycastHit hit, detectionRange))
            {
                return hit.transform.CompareTag("Player");
            }
            return false;
        }

        private Vector3 GetRandomPatrolPoint()
        {
            return patrolCenter + new Vector3(
                Random.Range(-50f, 50f),
                0f,
                Random.Range(-50f, 50f)
            );
        }

        private Vector3 GetFlankPosition()
        {
            if (playerTransform == null) return Vector3.zero;
            Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
            return Vector3.Cross(Vector3.up, toPlayer) * 10f * (packMembers.IndexOf(this) % 2 == 0 ? 1 : -1);
        }

        private Vector3 GetSurroundPosition()
        {
            if (playerTransform == null) return Vector3.zero;
            float angle = (packMembers.IndexOf(this) / (float)packMembers.Count) * Mathf.PI * 2f;
            return new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * 8f;
        }

        private void ChangeState(AIState newState)
        {
            if (currentState == newState) return;
            currentState = newState;
            stateTimer = 0f;
        }

        // Public methods called by external systems
        public void OnGrabbed(Transform grabberTransform)
        {
            isGrabbed = true;
            grabber = grabberTransform;
        }

        public void OnGrabReleased()
        {
            isGrabbed = false;
            grabber = null;
            ChangeState(AIState.Chase);
        }

        public void OnStunned(bool stunned)
        {
            if (stunned)
                bikeController.enabled = false;
            else
                bikeController.enabled = true;
        }

        public void OnDismounted()
        {
            ChangeState(AIState.Dead);
        }

        public void SetPackLeader(bool leader)
        {
            isPackLeader = leader;
        }

        public void AddPackMember(EnemyAI member)
        {
            if (!packMembers.Contains(member))
                packMembers.Add(member);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }

    public enum AIState
    {
        Patrol,
        Chase,
        Attack,
        Flee,
        Frozen,
        Hesitant,
        Dead
    }

    public enum AIBehaviorType
    {
        Aggressive,
        Defensive,
        Evasive,
        Coordinated
    }
}
