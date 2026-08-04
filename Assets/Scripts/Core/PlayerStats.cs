using UnityEngine;
using System;

namespace AsphaltAnarchy.Core
{
    /// <summary>
    /// Persistent player progression data. Handles bike upgrades,
    /// currency, and unlocked abilities.
    /// </summary>
    public class PlayerStats : MonoBehaviour
    {
        [Header("Base Stats")]
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth;

        [Header("Bike Stats")]
        [SerializeField] private float enginePower = 150f;        // Horsepower
        [SerializeField] private float handlingRating = 5f;       // 1-10 scale
        [SerializeField] private float brakeForce = 2000f;
        [SerializeField] private float armorRating = 0f;          // Damage reduction %
        [SerializeField] private float nitrousCapacity = 100f;

        [Header("Economy")]
        [SerializeField] private int scrapParts = 0;
        [SerializeField] private int reputationTokens = 0;

        [Header("Unlocks")]
        [SerializeField] private bool hasNitrousUnlocked = false;
        [SerializeField] private bool hasHijackUnlocked = false;
        [SerializeField] private bool hasMythWalkUnlocked = false;

        public float MaxHealth => maxHealth;
        public float CurrentHealth 
        { 
            get => currentHealth; 
            private set => currentHealth = Mathf.Clamp(value, 0f, maxHealth); 
        }
        public float EnginePower => enginePower;
        public float HandlingRating => handlingRating;
        public float BrakeForce => brakeForce;
        public float ArmorRating => armorRating;
        public float NitrousCapacity => nitrousCapacity;
        public int ScrapParts => scrapParts;
        public int ReputationTokens => reputationTokens;
        public bool HasNitrousUnlocked => hasNitrousUnlocked;
        public bool HasHijackUnlocked => hasHijackUnlocked;
        public bool HasMythWalkUnlocked => hasMythWalkUnlocked;

        public static event Action<float> OnHealthChanged;
        public static event Action<float> OnMaxHealthChanged;
        public static event Action OnPlayerDied;
        public static event Action<int> OnScrapChanged;
        public static event Action<int> OnTokensChanged;

        private void Start()
        {
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(float damage, DamageType type = DamageType.Generic)
        {
            float finalDamage = damage * (1f - armorRating / 100f);
            CurrentHealth -= finalDamage;
            OnHealthChanged?.Invoke(CurrentHealth);

            if (CurrentHealth <= 0f)
            {
                OnPlayerDied?.Invoke();
                GameManager.Instance?.ChangeState(GameState.GameOver);
            }
        }

        public void Heal(float amount)
        {
            CurrentHealth += amount;
            OnHealthChanged?.Invoke(CurrentHealth);
        }

        public void AddScrap(int amount)
        {
            scrapParts += amount;
            OnScrapChanged?.Invoke(scrapParts);
        }

        public void AddTokens(int amount)
        {
            reputationTokens += amount;
            OnTokensChanged?.Invoke(reputationTokens);
        }

        public void UpgradeEngine(float powerIncrease, int cost)
        {
            if (scrapParts < cost) return;
            scrapParts -= cost;
            enginePower += powerIncrease;
            OnScrapChanged?.Invoke(scrapParts);
        }

        public void UpgradeHandling(float handlingIncrease, int cost)
        {
            if (scrapParts < cost) return;
            scrapParts -= cost;
            handlingRating = Mathf.Clamp(handlingRating + handlingIncrease, 1f, 10f);
            OnScrapChanged?.Invoke(scrapParts);
        }

        public void UpgradeArmor(float armorIncrease, int cost)
        {
            if (scrapParts < cost) return;
            scrapParts -= cost;
            armorRating = Mathf.Clamp(armorRating + armorIncrease, 0f, 75f);
            OnScrapChanged?.Invoke(scrapParts);
        }

        public void UnlockNitrous(int cost)
        {
            if (hasNitrousUnlocked || scrapParts < cost) return;
            scrapParts -= cost;
            hasNitrousUnlocked = true;
            OnScrapChanged?.Invoke(scrapParts);
        }

        public void UnlockHijack(int cost)
        {
            if (hasHijackUnlocked || scrapParts < cost) return;
            scrapParts -= cost;
            hasHijackUnlocked = true;
            OnScrapChanged?.Invoke(scrapParts);
        }

        public void UnlockMythWalk()
        {
            hasMythWalkUnlocked = true;
        }

        public PlayerSerializableData GetSerializableData()
        {
            return new PlayerSerializableData
            {
                maxHealth = maxHealth,
                currentHealth = currentHealth,
                enginePower = enginePower,
                handlingRating = handlingRating,
                brakeForce = brakeForce,
                armorRating = armorRating,
                nitrousCapacity = nitrousCapacity,
                scrapParts = scrapParts,
                reputationTokens = reputationTokens,
                hasNitrousUnlocked = hasNitrousUnlocked,
                hasHijackUnlocked = hasHijackUnlocked,
                hasMythWalkUnlocked = hasMythWalkUnlocked
            };
        }

        public void LoadFromSerializableData(PlayerSerializableData data)
        {
            maxHealth = data.maxHealth;
            currentHealth = data.currentHealth;
            enginePower = data.enginePower;
            handlingRating = data.handlingRating;
            brakeForce = data.brakeForce;
            armorRating = data.armorRating;
            nitrousCapacity = data.nitrousCapacity;
            scrapParts = data.scrapParts;
            reputationTokens = data.reputationTokens;
            hasNitrousUnlocked = data.hasNitrousUnlocked;
            hasHijackUnlocked = data.hasHijackUnlocked;
            hasMythWalkUnlocked = data.hasMythWalkUnlocked;

            OnHealthChanged?.Invoke(CurrentHealth);
            OnScrapChanged?.Invoke(scrapParts);
            OnTokensChanged?.Invoke(reputationTokens);
        }
    }

    [System.Serializable]
    public class PlayerSerializableData
    {
        public float maxHealth;
        public float currentHealth;
        public float enginePower;
        public float handlingRating;
        public float brakeForce;
        public float armorRating;
        public float nitrousCapacity;
        public int scrapParts;
        public int reputationTokens;
        public bool hasNitrousUnlocked;
        public bool hasHijackUnlocked;
        public bool hasMythWalkUnlocked;
    }

    public enum DamageType
    {
        Generic,
        Melee,
        Crash,
        Fall,
        Explosion,
        Environmental
    }
}
