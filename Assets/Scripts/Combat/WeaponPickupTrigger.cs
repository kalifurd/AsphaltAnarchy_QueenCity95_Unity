using UnityEngine;

namespace AsphaltAnarchy.Combat
{
    /// <summary>
    /// Bare trigger-collider that unlocks a hand-assigned weapon on player entry.
    /// One per owned location (safehouse or acquired business). WeaponData is
    /// chosen by hand per node — no tier/level scaling system exists yet.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class WeaponPickupTrigger : MonoBehaviour
    {
        [SerializeField] private WeaponData weapon;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            var weaponManager = other.GetComponent<WeaponManager>();
            weaponManager?.UnlockWeapon(weapon);
        }
    }
}
