using UnityEngine;
using System.Collections;
using AsphaltAnarchy.Vehicle;
using AsphaltAnarchy.Core;
using AsphaltAnarchy.AI;
using AsphaltAnarchy.Echo;

namespace AsphaltAnarchy.Combat
{
    /// <summary>
    /// Handles the high-risk Grab and Hijack maneuvers.
    /// Grab: Reach out and steer enemy into obstacles.
    /// Hijack: Jump from bike, tackle enemy, steal their vehicle.
    /// </summary>
    public class GrabSystem : MonoBehaviour
    {
        [Header("Grab Settings")]
        [SerializeField] private float grabRange = 3f;
        [SerializeField] private float grabDuration = 2f;
        [SerializeField] private float grabSteerForce = 300f;
        [SerializeField] private LayerMask enemyLayer;

        [Header("Hijack Settings")]
        [SerializeField] private float hijackRange = 4f;
        [SerializeField] private float hijackJumpForce = 8f;
        [SerializeField] private float hijackWindowDuration = 1f;
        [SerializeField] private AnimationCurve hijackArc = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [Header("References")]
        [SerializeField] private Transform grabOrigin;
        [SerializeField] private Transform playerSeat;
        [SerializeField] private Rigidbody playerRb;

        private MotorcycleController bikeController;
        private PlayerStats playerStats;
        private bool isGrabbing;
        private bool isHijacking;
        private Transform grabbedTarget;
        private Rigidbody grabbedRb;

        public bool IsGrabbing => isGrabbing;
        public bool IsHijacking => isHijacking;
        public bool CanGrab => !isGrabbing && !isHijacking;
        public bool CanHijack => !isGrabbing && !isHijacking && playerStats?.HasHijackUnlocked == true;

        private void Start()
        {
            bikeController = GetComponentInParent<MotorcycleController>();
            playerStats = GetComponentInParent<PlayerStats>();
            if (playerRb == null)
                playerRb = GetComponentInParent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && CanGrab)
            {
                AttemptGrab();
            }

            if (Input.GetKeyDown(KeyCode.G) && CanHijack)
            {
                AttemptHijack();
            }
        }

        private void AttemptGrab()
        {
            Vector3 origin = grabOrigin ? grabOrigin.position : transform.position;
            Collider[] nearby = Physics.OverlapSphere(origin, grabRange, enemyLayer);

            Transform bestTarget = null;
            float bestAngle = float.MaxValue;

            foreach (var col in nearby)
            {
                Vector3 toTarget = (col.transform.position - origin).normalized;
                float angle = Vector3.Angle(transform.forward, toTarget);
                if (angle < 45f && angle < bestAngle)
                {
                    bestAngle = angle;
                    bestTarget = col.transform;
                }
            }

            if (bestTarget != null)
            {
                StartCoroutine(GrabRoutine(bestTarget));
            }
        }

        private IEnumerator GrabRoutine(Transform target)
        {
            isGrabbing = true;
            grabbedTarget = target;
            grabbedRb = target.GetComponent<Rigidbody>();
            var enemyController = target.GetComponent<EnemyAI>();
            enemyController?.OnGrabbed(transform);

            float timer = 0f;
            float steerInput = Input.GetAxis("Horizontal");

            while (timer < grabDuration && grabbedTarget != null)
            {
                timer += Time.deltaTime;
                steerInput = Input.GetAxis("Horizontal");

                if (grabbedRb != null)
                {
                    // Steer enemy bike
                    Vector3 steerTorque = transform.up * steerInput * grabSteerForce;
                    grabbedRb.AddTorque(steerTorque, ForceMode.Force);

                    // Pull them toward obstacles/traffic
                    Vector3 pullDir = (transform.position - grabbedTarget.position).normalized;
                    grabbedRb.AddForce(pullDir * 50f, ForceMode.Force);
                }

                // Risk: counter-attack or loss of balance
                if (Mathf.Abs(steerInput) > 0.8f && Random.value < 0.02f)
                {
                    // Counter-attack triggered
                    BreakGrab(true);
                    yield break;
                }

                yield return null;
            }

            BreakGrab(false);
        }

        private void BreakGrab(bool wasCountered)
        {
            isGrabbing = false;
            if (grabbedTarget != null)
            {
                var enemyController = grabbedTarget.GetComponent<EnemyAI>();
                enemyController?.OnGrabReleased();
            }
            grabbedTarget = null;
            grabbedRb = null;

            if (wasCountered)
            {
                // Apply penalty: loss of balance
                bikeController?.ApplyExternalTorque(Vector3.right * 200f);
                playerStats?.TakeDamage(15f, DamageType.Melee);
            }
        }

        private void AttemptHijack()
        {
            Vector3 origin = grabOrigin ? grabOrigin.position : transform.position;
            Collider[] nearby = Physics.OverlapSphere(origin, hijackRange, enemyLayer);

            Transform bestTarget = null;
            float bestScore = float.MaxValue;

            foreach (var col in nearby)
            {
                var enemyBike = col.GetComponent<MotorcycleController>();
                if (enemyBike == null) continue;

                float dist = Vector3.Distance(origin, col.transform.position);
                float speedDiff = Mathf.Abs(bikeController.CurrentSpeedMph - enemyBike.CurrentSpeedMph);
                float score = dist + speedDiff * 0.1f;

                if (score < bestScore)
                {
                    bestScore = score;
                    bestTarget = col.transform;
                }
            }

            if (bestTarget != null)
            {
                StartCoroutine(HijackRoutine(bestTarget));
            }
        }

        private IEnumerator HijackRoutine(Transform target)
        {
            isHijacking = true;
            GameManager.Instance?.ChangeState(GameState.Combat);

            Vector3 startPos = playerSeat.position;
            Vector3 targetPos = target.position + target.up * 1.5f;

            // Suspend the player's own physics control during the jump arc.
            // NOTE: we deliberately never reparent the player's Rigidbody-bearing
            // transform under the enemy bike's transform (the original approach) —
            // Unity does not support a Rigidbody nested under another Rigidbody's
            // hierarchy, it produces broken/jittery physics. Instead the player
            // keeps driving their own Rigidbody and simply gets teleported onto
            // the stolen bike's position once the target is dismounted.
            bikeController.enabled = false;
            if (playerRb != null)
                playerRb.isKinematic = true;

            // Jump arc
            float timer = 0f;
            while (timer < hijackWindowDuration)
            {
                timer += Time.deltaTime;
                float t = timer / hijackWindowDuration;
                float arcT = hijackArc.Evaluate(t);

                Vector3 currentPos = Vector3.Lerp(startPos, targetPos, t);
                currentPos.y += Mathf.Sin(arcT * Mathf.PI) * hijackJumpForce;

                transform.position = currentPos;

                // Check if we reached the target
                if (Vector3.Distance(transform.position, targetPos) < 1f)
                {
                    break;
                }

                yield return null;
            }

            // Tackle enemy off
            var enemyHealth = target.GetComponent<EnemyHealth>();
            var enemyBike = target.GetComponent<MotorcycleController>();

            if (enemyHealth != null && enemyBike != null)
            {
                Vector3 stolenVelocity = enemyBike.Rigidbody != null ? enemyBike.Rigidbody.linearVelocity : Vector3.zero;

                // Dismount enemy — EnemyHealth.Dismount already ragdolls, drops
                // loot, and self-destroys the old bike/rider after a delay, so
                // there's nothing left over to clean up manually.
                enemyHealth.Dismount((target.forward + Vector3.up) * 500f);

                yield return new WaitForSeconds(0.2f);

                // Snap the player's own bike onto the stolen bike's position,
                // carrying over its momentum.
                if (playerRb != null)
                {
                    playerRb.isKinematic = false;
                    playerRb.position = target.position;
                    playerRb.rotation = target.rotation;
                    playerRb.linearVelocity = stolenVelocity;
                    playerRb.angularVelocity = Vector3.zero;
                }

                // Award Echo points for hijack
                FindObjectOfType<EchoSystem>()?.AddPoints(50f, EchoSource.Hijack);
            }
            else
            {
                // Failed hijack - fall
                playerStats?.TakeDamage(30f, DamageType.Fall);
            }

            if (playerRb != null)
                playerRb.isKinematic = false;
            bikeController.enabled = true;
            isHijacking = false;
            GameManager.Instance?.ChangeState(GameState.Exploring);
        }

        private void OnDrawGizmosSelected()
        {
            if (grabOrigin == null) return;
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(grabOrigin.position, grabRange);
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(grabOrigin.position, hijackRange);
        }
    }
}
