using UnityEngine;
using System;
using System.Collections;

namespace AsphaltAnarchy.Core
{
    /// <summary>
    /// Dynamic weather system affecting handling, visibility, and atmosphere.
    /// Heavy rain, river mist, and fog impact gameplay.
    /// </summary>
    public class WeatherSystem : MonoBehaviour
    {
        [Header("Weather States")]
        [SerializeField] private WeatherType currentWeather = WeatherType.Clear;
        [SerializeField] private float weatherChangeInterval = 300f;

        [Header("Rain")]
        [SerializeField] private ParticleSystem rainParticles;
        [SerializeField] private float rainIntensity = 0f;
        [SerializeField] private float wetAsphaltGripMultiplier = 0.7f;

        [Header("Fog / Mist")]
        [SerializeField] private float fogDensity = 0f;
        [SerializeField] private float fogStartDistance = 50f;
        [SerializeField] private float fogEndDistance = 200f;

        [Header("Lighting")]
        [SerializeField] private Light sunLight;
        [SerializeField] private AnimationCurve timeOfDayCurve;
        [SerializeField] private float dayDuration = 1200f; // 20 minutes

        [Header("Audio")]
        [SerializeField] private AudioSource ambientAudio;
        [SerializeField] private AudioClip rainAmbient;
        [SerializeField] private AudioClip clearAmbient;

        private float weatherTimer;
        private float timeOfDay;

        public WeatherType CurrentWeather => currentWeather;
        public float CurrentGripMultiplier => GetGripMultiplier();
        public float VisibilityRange => fogEndDistance;

        public static event Action<WeatherType> OnWeatherChanged;
        public static event Action<float> OnFogDensityChanged;

        public void Initialize()
        {
            SetWeather(currentWeather);
        }

        private void Update()
        {
            weatherTimer += Time.deltaTime;
            if (weatherTimer >= weatherChangeInterval)
            {
                weatherTimer = 0f;
                ChangeWeather();
            }

            UpdateTimeOfDay();
            UpdateWeatherEffects();
        }

        private void ChangeWeather()
        {
            var weatherTypes = (WeatherType[])Enum.GetValues(typeof(WeatherType));
            WeatherType newWeather = weatherTypes[UnityEngine.Random.Range(0, weatherTypes.Length)];
            SetWeather(newWeather);
        }

        public void SetWeather(WeatherType weather)
        {
            currentWeather = weather;
            OnWeatherChanged?.Invoke(weather);

            switch (weather)
            {
                case WeatherType.Clear:
                    rainIntensity = 0f;
                    fogDensity = 0f;
                    break;
                case WeatherType.LightRain:
                    rainIntensity = 0.3f;
                    fogDensity = 0.01f;
                    break;
                case WeatherType.HeavyRain:
                    rainIntensity = 1f;
                    fogDensity = 0.03f;
                    break;
                case WeatherType.RiverMist:
                    rainIntensity = 0f;
                    fogDensity = 0.05f;
                    fogEndDistance = 80f;
                    break;
                case WeatherType.Fog:
                    rainIntensity = 0f;
                    fogDensity = 0.08f;
                    fogEndDistance = 50f;
                    break;
                case WeatherType.Storm:
                    rainIntensity = 1f;
                    fogDensity = 0.06f;
                    fogEndDistance = 60f;
                    break;
            }

            UpdateAudio();
        }

        private void UpdateWeatherEffects()
        {
            // Rain particles
            if (rainParticles != null)
            {
                var emission = rainParticles.emission;
                emission.rateOverTime = new ParticleSystem.MinMaxCurve(rainIntensity * 1000f);
            }

            // Fog
            RenderSettings.fog = fogDensity > 0f;
            RenderSettings.fogDensity = fogDensity;
            RenderSettings.fogStartDistance = fogStartDistance;
            RenderSettings.fogEndDistance = fogEndDistance;
            OnFogDensityChanged?.Invoke(fogDensity);
        }

        private void UpdateTimeOfDay()
        {
            timeOfDay += Time.deltaTime;
            float normalizedTime = (timeOfDay % dayDuration) / dayDuration;

            if (sunLight != null)
            {
                float intensity = timeOfDayCurve.Evaluate(normalizedTime);
                sunLight.intensity = intensity;

                // Rotate sun
                float angle = normalizedTime * 360f - 90f;
                sunLight.transform.rotation = Quaternion.Euler(angle, 0f, 0f);
            }
        }

        private void UpdateAudio()
        {
            if (ambientAudio == null) return;

            switch (currentWeather)
            {
                case WeatherType.HeavyRain:
                case WeatherType.Storm:
                    if (ambientAudio.clip != rainAmbient)
                    {
                        ambientAudio.clip = rainAmbient;
                        ambientAudio.Play();
                    }
                    break;
                default:
                    if (ambientAudio.clip != clearAmbient)
                    {
                        ambientAudio.clip = clearAmbient;
                        ambientAudio.Play();
                    }
                    break;
            }
        }

        private float GetGripMultiplier()
        {
            return currentWeather switch
            {
                WeatherType.LightRain => 0.85f,
                WeatherType.HeavyRain => wetAsphaltGripMultiplier,
                WeatherType.RiverMist => 0.9f,
                WeatherType.Fog => 1f,
                WeatherType.Storm => 0.6f,
                _ => 1f
            };
        }

        public void ForceStormForFinalConfrontation()
        {
            SetWeather(WeatherType.Storm);
            weatherTimer = -9999f; // Prevent auto-change
        }
    }

    public enum WeatherType
    {
        Clear,
        LightRain,
        HeavyRain,
        RiverMist,
        Fog,
        Storm
    }
}
