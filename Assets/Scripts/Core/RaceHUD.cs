using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using AsphaltAnarchy.Vehicle;
using AsphaltAnarchy.Echo;

namespace AsphaltAnarchy.Core
{
    /// <summary>
    /// Race HUD controller. Connects to UI elements in the scene and reacts
    /// to PlayerStats/EchoSystem events plus RaceManager callbacks.
    /// </summary>
    public class RaceHUD : MonoBehaviour
    {
        [Header("Player Reference")]
        [SerializeField] private MotorcycleController playerBike;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private EchoSystem echoSystem;

        [Header("Health")]
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TMP_Text healthText;

        [Header("Speedometer")]
        [SerializeField] private TMP_Text speedText;

        [Header("Echo Meter")]
        [SerializeField] private Slider echoSlider;
        [SerializeField] private TMP_Text echoLevelText;

        [Header("Race Info")]
        [SerializeField] private TMP_Text raceTimeText;
        [SerializeField] private TMP_Text lapText;
        [SerializeField] private TMP_Text countdownText;

        private void OnEnable()
        {
            PlayerStats.OnHealthChanged += HandleHealthChanged;
            EchoSystem.OnEchoPointsChanged += HandleEchoPointsChanged;
            EchoSystem.OnEchoLevelUp += HandleEchoLevelUp;
        }

        private void OnDisable()
        {
            PlayerStats.OnHealthChanged -= HandleHealthChanged;
            EchoSystem.OnEchoPointsChanged -= HandleEchoPointsChanged;
            EchoSystem.OnEchoLevelUp -= HandleEchoLevelUp;
        }

        private void Start()
        {
            if (playerStats != null && healthSlider != null)
                healthSlider.value = 1f;
            if (echoSystem != null && echoSlider != null)
                echoSlider.value = echoSystem.ProgressToNextLevel;
            if (countdownText != null)
                countdownText.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (playerBike != null && speedText != null)
                speedText.text = Mathf.RoundToInt(playerBike.CurrentSpeedMph) + " MPH";
        }

        private void HandleHealthChanged(float currentHealth)
        {
            float maxHealth = playerStats != null ? playerStats.MaxHealth : 100f;
            if (healthSlider != null)
                healthSlider.value = currentHealth / Mathf.Max(maxHealth, 1f);
            if (healthText != null)
                healthText.text = $"{Mathf.RoundToInt(currentHealth)} / {Mathf.RoundToInt(maxHealth)}";
        }

        private void HandleEchoPointsChanged(float points)
        {
            if (echoSlider != null && echoSystem != null)
                echoSlider.value = echoSystem.ProgressToNextLevel;
        }

        private void HandleEchoLevelUp(int level)
        {
            if (echoLevelText != null)
                echoLevelText.text = $"ECHO LV {level}";
        }

        public void ShowCountdown(int count)
        {
            if (countdownText == null) return;
            countdownText.gameObject.SetActive(count > 0);
            if (count > 0)
                countdownText.text = count.ToString();
        }

        public void UpdateRaceUI(float raceTime, int currentLap, int totalLaps, int currentCheckpoint, int totalCheckpoints)
        {
            if (raceTimeText != null)
                raceTimeText.text = FormatTime(raceTime);
            if (lapText != null)
                lapText.text = $"LAP {currentLap}/{totalLaps}  CP {currentCheckpoint}/{totalCheckpoints}";
        }

        public void ShowLapTime(float lapTime, float bestLap)
        {
            if (lapText != null)
                lapText.text += $"\nLap {FormatTime(lapTime)} (best {FormatTime(bestLap)})";
        }

        public void ShowResults(List<RaceResult> results)
        {
            if (raceTimeText == null) return;
            var summary = new System.Text.StringBuilder("RESULTS\n");
            foreach (var r in results)
                summary.AppendLine($"#{r.position}  {FormatTime(r.totalTime)}  best {FormatTime(r.bestLap)}");
            raceTimeText.text = summary.ToString();
        }

        private string FormatTime(float t)
        {
            int minutes = Mathf.FloorToInt(t / 60f);
            float seconds = t % 60f;
            return $"{minutes:00}:{seconds:00.000}";
        }
    }
}
