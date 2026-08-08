using UnityEngine;
using TMPro;

namespace AsphaltAnarchy.Factions
{
    /// <summary>
    /// Minimal text warning for a PlayerCrew-owned TurfNode under passive
    /// assault, so an undefended capture is never a silent instant loss.
    /// Tracks a single node at a time — if more than one node is under
    /// assault simultaneously, only the most recently started one shows.
    /// </summary>
    public class TurfAssaultHUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text warningText;

        private TurfNode watchedNode;

        private void OnEnable()
        {
            TurfNode.OnNodeAssaultStarted += HandleAssaultStarted;
            TurfNode.OnNodeAssaultResolved += HandleAssaultResolved;
        }

        private void OnDisable()
        {
            TurfNode.OnNodeAssaultStarted -= HandleAssaultStarted;
            TurfNode.OnNodeAssaultResolved -= HandleAssaultResolved;
        }

        private void Start()
        {
            if (warningText != null) warningText.text = string.Empty;
        }

        private void HandleAssaultStarted(TurfNode node)
        {
            watchedNode = node;
        }

        private void HandleAssaultResolved(TurfNode node)
        {
            if (watchedNode != node) return;

            watchedNode = null;
            if (warningText != null) warningText.text = string.Empty;
        }

        private void Update()
        {
            if (warningText == null || watchedNode == null) return;

            if (!watchedNode.IsUnderAssault)
            {
                watchedNode = null;
                warningText.text = string.Empty;
                return;
            }

            warningText.text = $"{watchedNode.NodeName} is under attack! Defend in {Mathf.CeilToInt(watchedNode.AssaultTimeRemaining)}s";
        }
    }
}
