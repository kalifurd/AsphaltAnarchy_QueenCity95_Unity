using UnityEngine;
using System.Collections;
using TMPro;
using AsphaltAnarchy.Core;
using AsphaltAnarchy.Combat;

namespace AsphaltAnarchy.World
{
    public enum NPCOutcomeType { Item, Upgrade, Info }
    public enum NPCUpgradeType { Engine, Handling, Armor, Nitrous, Hijack }

    /// <summary>
    /// Generic proximity + interact-key NPC. Reuses PlayerStats' existing
    /// cost-gated upgrade methods and WeaponManager's existing equip logic
    /// instead of duplicating that logic here.
    /// </summary>
    public class NPCInteraction : MonoBehaviour
    {
        [Header("Proximity")]
        [SerializeField] private float interactRange = 3f;
        [SerializeField] private Transform player;

        [Header("Outcome")]
        [SerializeField] private NPCOutcomeType outcomeType = NPCOutcomeType.Info;

        [Header("Item Outcome")]
        [SerializeField] private WeaponData itemToGive;

        [Header("Upgrade Outcome")]
        [SerializeField] private NPCUpgradeType upgradeType;
        [SerializeField] private float upgradeAmount = 10f;
        [SerializeField] private int upgradeCost = 0;

        [Header("Info Outcome")]
        [SerializeField, TextArea] private string infoMessage = "...";

        [Header("Feedback UI (shared HUD element)")]
        [SerializeField] private GameObject messagePanel;
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private float messageDuration = 3f;

        private PlayerStats playerStats;
        private WeaponManager playerWeapons;
        private bool hasInteracted;
        private Coroutine hideRoutine;

        private void Start()
        {
            if (player == null)
            {
                var playerGO = GameObject.FindGameObjectWithTag("Player");
                if (playerGO != null) player = playerGO.transform;
            }

            if (player != null)
            {
                playerStats = player.GetComponent<PlayerStats>();
                playerWeapons = player.GetComponent<WeaponManager>();
            }
        }

        private void Update()
        {
            if (player == null || InputManager.Instance == null) return;

            // Item/Upgrade are one-time gifts — without this gate, holding E
            // near the NPC would re-trigger PlayerStats' cost-gated methods
            // every frame (free infinite upgrades). Info has nothing to gate.
            if (hasInteracted && outcomeType != NPCOutcomeType.Info) return;

            if (!InputManager.Instance.InteractPressed) return;

            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= interactRange)
            {
                Interact();
            }
        }

        private void Interact()
        {
            switch (outcomeType)
            {
                case NPCOutcomeType.Item:
                    GiveItem();
                    break;
                case NPCOutcomeType.Upgrade:
                    GiveUpgrade();
                    break;
                case NPCOutcomeType.Info:
                    ShowMessage(infoMessage);
                    break;
            }
        }

        private void GiveItem()
        {
            if (playerWeapons == null || itemToGive == null) return;
            playerWeapons.UnlockWeapon(itemToGive);
            playerWeapons.EquipWeapon(itemToGive);
            hasInteracted = true;
            ShowMessage($"Received: {itemToGive.weaponName}");
        }

        private void GiveUpgrade()
        {
            if (playerStats == null) return;

            switch (upgradeType)
            {
                case NPCUpgradeType.Engine:
                    playerStats.UpgradeEngine(upgradeAmount, upgradeCost);
                    break;
                case NPCUpgradeType.Handling:
                    playerStats.UpgradeHandling(upgradeAmount, upgradeCost);
                    break;
                case NPCUpgradeType.Armor:
                    playerStats.UpgradeArmor(upgradeAmount, upgradeCost);
                    break;
                case NPCUpgradeType.Nitrous:
                    playerStats.UnlockNitrous(upgradeCost);
                    break;
                case NPCUpgradeType.Hijack:
                    playerStats.UnlockHijack(upgradeCost);
                    break;
            }

            hasInteracted = true;
            ShowMessage($"Upgrade received: {upgradeType}");
        }

        private void ShowMessage(string message)
        {
            if (messagePanel == null || messageText == null) return;

            messageText.text = message;
            messagePanel.SetActive(true);

            if (hideRoutine != null) StopCoroutine(hideRoutine);
            hideRoutine = StartCoroutine(HideAfterDelay());
        }

        private IEnumerator HideAfterDelay()
        {
            yield return new WaitForSeconds(messageDuration);
            if (messagePanel != null) messagePanel.SetActive(false);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, interactRange);
        }
    }
}
