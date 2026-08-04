using UnityEngine;

namespace AsphaltAnarchy.Combat
{
    /// <summary>
    /// Defines a melee weapon available in vehicular combat.
    /// ScriptableObject for designer-friendly weapon creation.
    /// </summary>
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Asphalt Anarchy/Weapon")]
    public class WeaponData : ScriptableObject
    {
        [Header("Identity")]
        public string weaponName = "Baseball Bat";
        public string description = "A classic street weapon.";
        public Sprite icon;

        [Header("Combat Stats")]
        [Tooltip("Base damage dealt on a successful hit.")]
        public float baseDamage = 25f;

        [Tooltip("Weight affects swing speed at high velocity. Heavier = slower but more damage.")]
        [Range(0.5f, 10f)]
        public float weight = 2f;

        [Tooltip("Reach of the weapon in meters.")]
        public float reach = 2f;

        [Tooltip("Time between swings in seconds.")]
        public float swingCooldown = 0.8f;

        [Tooltip("Knockback force applied to target.")]
        public float knockbackForce = 500f;

        [Tooltip("Chance to instantly dismount opponent (0-1).")]
        [Range(0f, 1f)]
        public float dismountChance = 0.15f;

        [Header("Speed Modifiers")]
        [Tooltip("Damage multiplier at high speed (120mph+).")]
        public float highSpeedMultiplier = 2.5f;

        [Tooltip("Speed threshold in m/s for high-speed bonus.")]
        public float highSpeedThreshold = 53f; // ~120mph

        [Header("Special Properties")]
        public bool isElectrified = false;
        public float stunDuration = 0f;
        public bool canGrab = false;
        public bool isHeavy = false;

        [Header("Audio")]
        public AudioClip swingSound;
        public AudioClip impactSound;
        public AudioClip dismountSound;
    }
}
