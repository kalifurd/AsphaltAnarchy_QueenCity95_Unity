using UnityEngine;
using AsphaltAnarchy.Core;

namespace AsphaltAnarchy.World
{
    /// <summary>
    /// Always-on save trigger, independent of TurfNode/hasSafehouse ownership
    /// state. Price Hill's guaranteed fallback — saves regardless of what turf
    /// is lost elsewhere, not contestable like a TurfNode-gated safehouse.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class PermanentSavePoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            GameManager.Instance?.SaveGame();
        }
    }
}
