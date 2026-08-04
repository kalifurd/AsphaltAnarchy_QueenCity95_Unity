using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace AsphaltAnarchy.Heat
{
    /// <summary>
    /// Single flaming HEAT graphic that doubles as the meter: transparent at
    /// zero heat, opacity/scale ramp up with the heat value, a brief
    /// flash/punch when a wave triggers, and a fade back down during the
    /// evasion cooldown countdown.
    /// </summary>
    public class HeatHUD : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image flameImage;

        [Header("Look")]
        [SerializeField] private float minAlpha = 0f;
        [SerializeField] private float maxAlpha = 1f;
        [SerializeField] private float minScale = 0.85f;
        [SerializeField] private float maxScale = 1.25f;

        [Header("Wave Punch")]
        [SerializeField] private float punchScale = 1.6f;
        [SerializeField] private float punchDuration = 0.25f;

        private Coroutine punchRoutine;

        private void OnEnable()
        {
            HeatSystem.OnHeatChanged += HandleHeatChanged;
            HeatSystem.OnWaveTriggered += HandleWaveTriggered;
            HeatSystem.OnHeatCleared += HandleHeatCleared;
        }

        private void OnDisable()
        {
            HeatSystem.OnHeatChanged -= HandleHeatChanged;
            HeatSystem.OnWaveTriggered -= HandleWaveTriggered;
            HeatSystem.OnHeatCleared -= HandleHeatCleared;
        }

        private void Start()
        {
            ApplyFraction(0f);
        }

        private void HandleHeatChanged(float currentHeat)
        {
            var heatSystem = FindObjectOfType<HeatSystem>();
            float fraction = heatSystem != null ? heatSystem.HeatFraction : 0f;
            ApplyFraction(fraction);
        }

        private void HandleHeatCleared()
        {
            ApplyFraction(0f);
        }

        private void ApplyFraction(float fraction)
        {
            if (flameImage == null) return;

            var color = flameImage.color;
            color.a = Mathf.Lerp(minAlpha, maxAlpha, fraction);
            flameImage.color = color;

            float scale = Mathf.Lerp(minScale, maxScale, fraction);
            flameImage.rectTransform.localScale = Vector3.one * scale;
        }

        private void HandleWaveTriggered()
        {
            if (punchRoutine != null)
                StopCoroutine(punchRoutine);
            punchRoutine = StartCoroutine(PunchRoutine());
        }

        private IEnumerator PunchRoutine()
        {
            if (flameImage == null) yield break;

            float baseScale = flameImage.rectTransform.localScale.x;
            float elapsed = 0f;

            while (elapsed < punchDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / punchDuration;
                float scale = Mathf.Lerp(punchScale, baseScale, t);
                flameImage.rectTransform.localScale = Vector3.one * scale;
                yield return null;
            }

            flameImage.rectTransform.localScale = Vector3.one * baseScale;
            punchRoutine = null;
        }
    }
}
