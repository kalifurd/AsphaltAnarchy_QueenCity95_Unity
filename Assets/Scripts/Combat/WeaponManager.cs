using UnityEngine;
using System.Collections.Generic;
using AsphaltAnarchy.Vehicle;

namespace AsphaltAnarchy.Combat
{
    /// <summary>
    /// Manages equipped weapons, swing timing, and hit detection.
    /// Attached to the player or AI rider.
    /// </summary>
    public class WeaponManager : MonoBehaviour
    {
        [Header("Weapon Slots")]
        [SerializeField] private WeaponData currentWeapon;
        [SerializeField] private List<WeaponData> unlockedWeapons = new List<WeaponData>();
        [SerializeField] private Transform weaponPivot;
        [SerializeField] private Transform weaponMesh;

        [Header("Detection")]
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private Transform attackOrigin;

        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;

        private MotorcycleController bikeController;
        private float lastSwingTime;
        private bool isSwinging;
        private int currentWeaponIndex;

        public WeaponData CurrentWeapon => currentWeapon;
        public bool IsSwinging => isSwinging;
        public bool CanSwing => currentWeapon != null && Time.time >= lastSwingTime + GetModifiedCooldown();

        private void Start()
        {
            bikeController = GetComponentInParent<MotorcycleController>();
            if (currentWeapon != null && !unlockedWeapons.Contains(currentWeapon))
                unlockedWeapons.Add(currentWeapon);
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetButtonDown("Fire1") && CanSwing)
            {
                PerformSwing();
            }

            // Weapon switch
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CycleWeapon(-1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                CycleWeapon(1);
            }
        }

        public void PerformSwing()
        {
            if (currentWeapon == null) return;

            isSwinging = true;
            lastSwingTime = Time.time;

            // Play swing animation/sound
            PlaySwingEffects();

            // Calculate modified stats based on speed
            float speed = bikeController?.CurrentSpeedMph ?? 0f;
            float speedPenalty = Mathf.Clamp01(speed / 120f) * currentWeapon.weight * 0.1f;
            float actualCooldown = currentWeapon.swingCooldown + speedPenalty;

            // Perform hit detection after a brief delay (swing arc)
            Invoke(nameof(ExecuteHitDetection), 0.15f);
            Invoke(nameof(EndSwing), 0.3f);
        }

        private void ExecuteHitDetection()
        {
            if (currentWeapon == null) return;

            Vector3 origin = attackOrigin ? attackOrigin.position : transform.position;
            float reach = currentWeapon.reach;
            float radius = 0.5f;

            Collider[] hits = Physics.OverlapSphere(origin, radius, enemyLayer);
            foreach (var hit in hits)
            {
                // Check if target is within reach angle (front cone)
                Vector3 toTarget = (hit.transform.position - origin).normalized;
                float angle = Vector3.Angle(transform.forward, toTarget);
                if (angle > 60f) continue;

                // Check distance
                float distance = Vector3.Distance(origin, hit.transform.position);
                if (distance > reach) continue;

                // Apply damage
                ProcessHit(hit);
            }
        }

        private void ProcessHit(Collider targetCollider)
        {
            float speed = bikeController?.CurrentSpeedMph ?? 0f;
            float damage = currentWeapon.baseDamage;
            float knockback = currentWeapon.knockbackForce;

            // High speed bonus
            if (speed >= currentWeapon.highSpeedThreshold * 2.237f)
            {
                damage *= currentWeapon.highSpeedMultiplier;
                knockback *= 1.5f;
            }

            // Apply to enemy
            var enemyHealth = targetCollider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, currentWeapon.isElectrified);

                // Knockback
                var enemyRb = targetCollider.GetComponent<Rigidbody>();
                if (enemyRb != null)
                {
                    Vector3 knockDir = (targetCollider.transform.position - transform.position).normalized;
                    knockDir += Vector3.up * 0.3f;
                    enemyRb.AddForce(knockDir * knockback, ForceMode.Impulse);
                }

                // Dismount chance
                if (Random.value < currentWeapon.dismountChance)
                {
                    enemyHealth.Dismount(transform.forward * knockback * 2f);
                }

                // Stun
                if (currentWeapon.stunDuration > 0f)
                {
                    enemyHealth.Stun(currentWeapon.stunDuration);
                }
            }

            // Play impact effects
            PlayImpactEffects(targetCollider.transform.position);
        }

        private void EndSwing()
        {
            isSwinging = false;
        }

        private float GetModifiedCooldown()
        {
            if (currentWeapon == null) return 999f;
            float speed = bikeController?.CurrentSpeedMph ?? 0f;
            float penalty = Mathf.Clamp01(speed / 120f) * currentWeapon.weight * 0.1f;
            return currentWeapon.swingCooldown + penalty;
        }

        public void EquipWeapon(WeaponData weapon)
        {
            if (weapon == null) return;
            currentWeapon = weapon;
            // Update visual mesh
            // TODO: Swap weapon model on weaponMesh
        }

        public void UnlockWeapon(WeaponData weapon)
        {
            if (weapon == null || unlockedWeapons.Contains(weapon)) return;
            unlockedWeapons.Add(weapon);
        }

        private void CycleWeapon(int direction)
        {
            if (unlockedWeapons.Count <= 1) return;
            currentWeaponIndex = (currentWeaponIndex + direction + unlockedWeapons.Count) % unlockedWeapons.Count;
            EquipWeapon(unlockedWeapons[currentWeaponIndex]);
        }

        private void PlaySwingEffects()
        {
            if (audioSource != null && currentWeapon?.swingSound != null)
                audioSource.PlayOneShot(currentWeapon.swingSound);
        }

        private void PlayImpactEffects(Vector3 position)
        {
            if (audioSource != null && currentWeapon?.impactSound != null)
                audioSource.PlayOneShot(currentWeapon.impactSound);

            // TODO: Spawn impact particle effect at position
        }

        private void OnDrawGizmosSelected()
        {
            if (currentWeapon == null || attackOrigin == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackOrigin.position, currentWeapon.reach);
        }
    }
}
