using UnityEngine;
using AsphaltAnarchy.Factions;

namespace AsphaltAnarchy.Heat
{
    /// <summary>
    /// Placed on one half of a jurisdiction boundary (e.g. one side of a
    /// state-line river bridge's midpoint) — entering it hands pursuit off
    /// to assignedFaction via HeatSystem.HandleJurisdictionCrossing().
    /// </summary>
    public class JurisdictionCrossingTrigger : MonoBehaviour
    {
        [SerializeField] private FactionData assignedFaction;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            var heatSystem = FindObjectOfType<HeatSystem>();
            if (heatSystem == null) return;

            heatSystem.HandleJurisdictionCrossing(assignedFaction);
        }
    }
}
