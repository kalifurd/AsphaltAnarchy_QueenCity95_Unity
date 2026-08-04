using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using AsphaltAnarchy.Vehicle;
using AsphaltAnarchy.Echo;

namespace AsphaltAnarchy.Core
{
    /// <summary>
    /// Manages race events: start, checkpoints, lap timing, and completion.
    /// </summary>
    public class RaceManager : MonoBehaviour
    {
        [Header("Race Configuration")]
        [SerializeField] private List<Transform> checkpoints;
        [SerializeField] private int totalLaps = 1;
        [SerializeField] private float countdownDuration = 3f;

        [Header("Participants")]
        [SerializeField] private MotorcycleController playerBike;
        [SerializeField] private List<MotorcycleController> aiRiders;

        [Header("UI")]
        [SerializeField] private RaceHUD raceHUD;

        private bool raceActive;
        private bool raceFinished;
        private int currentCheckpoint;
        private int currentLap;
        private float raceTime;
        private float bestLapTime = float.MaxValue;
        private float currentLapStartTime;
        private List<RaceResult> results = new List<RaceResult>();

        public bool RaceActive => raceActive;
        public float RaceTime => raceTime;
        public int CurrentLap => currentLap;
        public int CurrentCheckpoint => currentCheckpoint;

        public static event Action OnRaceStarted;
        public static event Action OnRaceFinished;
        public static event Action<float> OnLapCompleted;

        public void StartRace()
        {
            StartCoroutine(CountdownAndStart());
        }

        private IEnumerator CountdownAndStart()
        {
            GameManager.Instance?.ChangeState(GameState.Racing);

            // Countdown
            float timer = countdownDuration;
            while (timer > 0f)
            {
                raceHUD?.ShowCountdown(Mathf.CeilToInt(timer));
                timer -= Time.deltaTime;
                yield return null;
            }

            raceHUD?.ShowCountdown(0);
            raceActive = true;
            raceFinished = false;
            currentCheckpoint = 0;
            currentLap = 1;
            raceTime = 0f;
            currentLapStartTime = Time.time;
            results.Clear();

            // Enable all participants
            playerBike.enabled = true;
            foreach (var ai in aiRiders)
                ai.enabled = true;

            OnRaceStarted?.Invoke();
        }

        private void Update()
        {
            if (!raceActive) return;
            raceTime += Time.deltaTime;
            raceHUD?.UpdateRaceUI(raceTime, currentLap, totalLaps, currentCheckpoint, checkpoints.Count);
        }

        public void OnCheckpointReached(MotorcycleController rider, int checkpointIndex)
        {
            if (!raceActive) return;

            if (rider == playerBike)
            {
                if (checkpointIndex == currentCheckpoint)
                {
                    currentCheckpoint++;

                    if (currentCheckpoint >= checkpoints.Count)
                    {
                        currentCheckpoint = 0;
                        CompleteLap();
                    }
                }
            }
            else
            {
                // Track AI progress
                var aiResult = results.Find(r => r.rider == rider);
                if (aiResult == null)
                {
                    aiResult = new RaceResult { rider = rider };
                    results.Add(aiResult);
                }
                aiResult.checkpointsPassed++;
            }
        }

        private void CompleteLap()
        {
            float lapTime = Time.time - currentLapStartTime;
            currentLapStartTime = Time.time;

            if (lapTime < bestLapTime)
                bestLapTime = lapTime;

            OnLapCompleted?.Invoke(lapTime);
            raceHUD?.ShowLapTime(lapTime, bestLapTime);

            currentLap++;
            if (currentLap > totalLaps)
            {
                FinishRace(true);
            }
        }

        public void FinishRace(bool playerWon)
        {
            raceActive = false;
            raceFinished = true;

            var playerResult = new RaceResult
            {
                rider = playerBike,
                totalTime = raceTime,
                bestLap = bestLapTime,
                position = playerWon ? 1 : 2
            };
            results.Add(playerResult);

            // Sort by position
            results.Sort((a, b) => a.position.CompareTo(b.position));

            raceHUD?.ShowResults(results);
            OnRaceFinished?.Invoke();

            if (playerWon)
            {
                var echo = FindObjectOfType<EchoSystem>();
                echo?.AddPoints(100f, EchoSource.RaceWin);
            }

            GameManager.Instance?.ChangeState(GameState.Exploring);
        }

        public void ForfeitRace()
        {
            raceActive = false;
            GameManager.Instance?.ChangeState(GameState.Exploring);
        }
    }

    [System.Serializable]
    public class RaceResult
    {
        public MotorcycleController rider;
        public float totalTime;
        public float bestLap;
        public int position;
        public int checkpointsPassed;
    }
}
