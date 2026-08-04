using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AsphaltAnarchy.Core
{
    /// <summary>
    /// Upgrade shop panel. Toggled with a key, spends PlayerStats' scrap on
    /// Engine/Handling/Armor upgrades and the Nitrous unlock.
    /// </summary>
    public class ShopUI : MonoBehaviour
    {
        [Header("Player Reference")]
        [SerializeField] private PlayerStats playerStats;

        [Header("Panel")]
        [SerializeField] private GameObject shopPanel;
        [SerializeField] private KeyCode toggleKey = KeyCode.B;
        [SerializeField] private TMP_Text scrapText;

        [Header("Engine Upgrade")]
        [SerializeField] private Button engineButton;
        [SerializeField] private TMP_Text engineLabel;
        [SerializeField] private float enginePowerIncrease = 10f;
        [SerializeField] private int engineCost = 100;

        [Header("Handling Upgrade")]
        [SerializeField] private Button handlingButton;
        [SerializeField] private TMP_Text handlingLabel;
        [SerializeField] private float handlingIncrease = 1f;
        [SerializeField] private int handlingCost = 100;

        [Header("Armor Upgrade")]
        [SerializeField] private Button armorButton;
        [SerializeField] private TMP_Text armorLabel;
        [SerializeField] private float armorIncrease = 5f;
        [SerializeField] private int armorCost = 100;

        [Header("Nitrous Unlock")]
        [SerializeField] private Button nitrousButton;
        [SerializeField] private TMP_Text nitrousLabel;
        [SerializeField] private int nitrousCost = 150;

        private void OnEnable()
        {
            PlayerStats.OnScrapChanged += HandleScrapChanged;
            engineButton?.onClick.AddListener(BuyEngine);
            handlingButton?.onClick.AddListener(BuyHandling);
            armorButton?.onClick.AddListener(BuyArmor);
            nitrousButton?.onClick.AddListener(BuyNitrous);
        }

        private void OnDisable()
        {
            PlayerStats.OnScrapChanged -= HandleScrapChanged;
            engineButton?.onClick.RemoveListener(BuyEngine);
            handlingButton?.onClick.RemoveListener(BuyHandling);
            armorButton?.onClick.RemoveListener(BuyArmor);
            nitrousButton?.onClick.RemoveListener(BuyNitrous);
        }

        private void Start()
        {
            if (shopPanel != null)
                shopPanel.SetActive(false);
            RefreshUI();
        }

        private void Update()
        {
            if (shopPanel != null && Input.GetKeyDown(toggleKey))
            {
                bool willOpen = !shopPanel.activeSelf;
                shopPanel.SetActive(willOpen);
                if (willOpen)
                    RefreshUI();
            }
        }

        private void HandleScrapChanged(int scrap)
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            if (playerStats == null) return;

            if (scrapText != null)
                scrapText.text = $"Scrap: {playerStats.ScrapParts}";

            SetRow(engineLabel, engineButton, $"Engine +{enginePowerIncrease:0} HP", engineCost, true);
            SetRow(handlingLabel, handlingButton, $"Handling +{handlingIncrease:0.0}", handlingCost, true);
            SetRow(armorLabel, armorButton, $"Armor +{armorIncrease:0}%", armorCost, true);
            SetRow(nitrousLabel, nitrousButton, "Nitrous Unlock", nitrousCost, !playerStats.HasNitrousUnlocked);
        }

        private void SetRow(TMP_Text label, Button button, string title, int cost, bool purchasable)
        {
            if (label != null)
                label.text = purchasable ? $"{title} — {cost} scrap" : $"{title} — OWNED";
            if (button != null)
                button.interactable = purchasable && playerStats.ScrapParts >= cost;
        }

        private void BuyEngine() => playerStats.UpgradeEngine(enginePowerIncrease, engineCost);
        private void BuyHandling() => playerStats.UpgradeHandling(handlingIncrease, handlingCost);
        private void BuyArmor() => playerStats.UpgradeArmor(armorIncrease, armorCost);
        private void BuyNitrous() => playerStats.UnlockNitrous(nitrousCost);
    }
}
