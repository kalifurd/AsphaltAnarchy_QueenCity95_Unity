using UnityEngine;
using System;
using System.Collections;
using AsphaltAnarchy.Vehicle;
using AsphaltAnarchy.AI;
using AsphaltAnarchy.Core;
using AsphaltAnarchy.Echo;

namespace AsphaltAnarchy.Combat
{
    /// <summary>
    /// Health and damage handling for enemy riders.
    /// Supports dismounting, stunning, and death states.
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private float maxHealth = 80f;
        [SerializeField] private float currentHealth;

        [Header("Dismount")]
        [SerializeField] private float dismountThreshold = 0.3f;
        [SerializeField] private float ragdollDuration = 5f;
        [SerializeField] private GameObject bikePrefab;
        [SerializeField] private GameObject ragdollPrefab;

        [Header("Effects")]
        [SerializeField] private ParticleSystem damageParticles;
        [SerializeField] private ParticleSystem sparkParticles;

        private MotorcycleController bikeController;
        private EnemyAI enemyAI;
        private Rigidbody rb;
        private bool isDismounted;
        private bool isStunned;
        private bool isDead;

        public float MaxHealth => maxHealth;
        public float CurrentHealth => currentHealth;
        public bool IsDismounted => isDismounted;
        public bool IsStunned => isStunned;
        public bool IsDead => isDead;
        public bool IsAlive => !isDead;

        public static event Action<EnemyHealth> OnEnemyDied;
        public static event Action<EnemyHealth> OnEnemyDismounted;

        private void Start()
        {
            currentHealth = maxHealth;
            bikeController = GetComponent<MotorcycleController>();
            enemyAI = GetComponent<EnemyAI>();
            rb = GetComponent<Rigidbody>();
        }

        public void TakeDamage(float damage, bool isElectrified = false)
        {
            if (isDead) return;

            currentHealth -= damage;

            if (isElectrified)
            {
                sparkParticles?.Play();
                Stun(1f);
            }

            if (currentHealth <= 0f)
            {
                Die();
            }
            else if (currentHealth / maxHealth <= dismountThreshold && !isDismounted)
            {
                Dismount(Vector3.zero);
            }
            else
            {
                damageParticles?.Play();
            }
        }

        public void Stun(float duration)
        {
            if (isDead || isDismounted) return;
            StartCoroutine(StunRoutine(duration));
        }

        private IEnumerator StunRoutine(float duration)
        {
            isStunned = true;
            enemyAI?.OnStunned(true);
            yield return new WaitForSeconds(duration);
            isStunned = false;
            enemyAI?.OnStunned(false);
        }

        public void Dismount(Vector3 ejectForce)
        {
            if (isDismounted || isDead) return;
            isDismounted = true;

            // Disable AI and bike controller
            enemyAI?.OnDismounted();
            if (bikeController != null)
                bikeController.enabled = false;

            // Apply ejection force
            if (rb != null && ejectForce != Vector3.zero)
            {
                rb.AddForce(ejectForce, ForceMode.Impulse);
                rb.AddTorque(UnityEngine.Random.insideUnitSphere * 10f, ForceMode.Impulse);
            }

            // Spawn ragdoll or bike wreck
            if (ragdollPrefab != null)
            {
                var ragdoll = Instantiate(ragdollPrefab, transform.position, transform.rotation);
                var ragdollRb = ragdoll.GetComponent<Rigidbody>();
                if (ragdollRb != null)
                {
                    ragdollRb.linearVelocity = rb?.linearVelocity ?? Vector3.zero;
                    ragdollRb.AddForce(ejectForce * 0.5f, ForceMode.Impulse);
                }
            }

            OnEnemyDismounted?.Invoke(this);

            // Drop scrap
            DropLoot();

            // Destroy after delay
            StartCoroutine(DestroyAfterDelay(ragdollDuration));
        }

        private void Die()
        {
            if (isDead) return;
            isDead = true;
            currentHealth = 0f;

            Dismount(transform.forward * 300f + Vector3.up * 200f);
            OnEnemyDied?.Invoke(this);
        }

        private void DropLoot()
        {
            // Drop scrap parts
            int scrapAmount = UnityEngine.Random.Range(5, 20);
            var playerStats = FindObjectOfType<PlayerStats>();
            playerStats?.AddScrap(scrapAmount);

            // Award Echo points
            var echoSystem = FindObjectOfType<EchoSystem>();
            echoSystem?.AddPoints(10f, EchoSource.Combat);
        }

        private IEnumerator DestroyAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }

        public void OnGrabbed(Transform grabber)
        {
            enemyAI?.OnGrabbed(grabber);
        }

        public void OnGrabReleased()
        {
            enemyAI?.OnGrabReleased();
        }
    }
}
