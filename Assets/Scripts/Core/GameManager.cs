using UnityEngine;
using System;
using System.Collections.Generic;
using AsphaltAnarchy.Echo;
using AsphaltAnarchy.Factions;
using AsphaltAnarchy.Vehicle;

namespace AsphaltAnarchy.Core
{
    /// <summary>
    /// Central game state manager. Handles scene transitions, save/load,
    /// and broadcasts global game events.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Systems")]
        [SerializeField] private EchoSystem echoSystem;
        [SerializeField] private FactionManager factionManager;
        [SerializeField] private TurfWarManager turfWarManager;
        [SerializeField] private WeatherSystem weatherSystem;

        [Header("Player")]
        [SerializeField] private MotorcycleController playerBike;
        [SerializeField] private PlayerStats playerStats;

        public GameState CurrentState { get; private set; } = GameState.MainMenu;
        public static event Action<GameState> OnGameStateChanged;
        public static event Action OnGameSaved;
        public static event Action OnGameLoaded;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            echoSystem?.Initialize(playerStats);
            factionManager?.Initialize();
            turfWarManager?.Initialize(factionManager, echoSystem);
            weatherSystem?.Initialize();

            ChangeState(GameState.Exploring);
        }

        public void ChangeState(GameState newState)
        {
            if (CurrentState == newState) return;
            CurrentState = newState;
            OnGameStateChanged?.Invoke(newState);
            Debug.Log($"[GameManager] State changed to: {newState}");
        }

        public void SaveGame()
        {
            var saveData = new SaveData
            {
                playerPosition = playerBike.transform.position,
                playerRotation = playerBike.transform.rotation,
                playerStats = playerStats.GetSerializableData(),
                echoLevel = echoSystem.CurrentLevel,
                echoPoints = echoSystem.CurrentPoints,
                factionData = factionManager.GetSerializableData(),
                turfNodeData = turfWarManager.GetSerializableData(),
                timestamp = DateTime.Now.ToString("O")
            };

            string json = JsonUtility.ToJson(saveData, true);
            System.IO.File.WriteAllText(GetSavePath(), json);
            OnGameSaved?.Invoke();
            Debug.Log("[GameManager] Game saved.");
        }

        public void LoadGame()
        {
            string path = GetSavePath();
            if (!System.IO.File.Exists(path))
            {
                Debug.LogWarning("[GameManager] No save file found.");
                return;
            }

            string json = System.IO.File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            playerBike.transform.SetPositionAndRotation(saveData.playerPosition, saveData.playerRotation);
            playerStats.LoadFromSerializableData(saveData.playerStats);
            echoSystem.LoadData(saveData.echoLevel, saveData.echoPoints);
            factionManager.LoadFromSerializableData(saveData.factionData);
            turfWarManager.LoadFromSerializableData(saveData.turfNodeData);

            OnGameLoaded?.Invoke();
            Debug.Log("[GameManager] Game loaded.");
        }

        private string GetSavePath()
        {
            return System.IO.Path.Combine(Application.persistentDataPath, "asphalt_anarchy_save.json");
        }
    }

    public enum GameState
    {
        MainMenu,
        Exploring,
        Racing,
        Combat,
        Cutscene,
        Paused,
        GameOver
    }

    [Serializable]
    public class SaveData
    {
        public Vector3 playerPosition;
        public Quaternion playerRotation;
        public PlayerSerializableData playerStats;
        public int echoLevel;
        public float echoPoints;
        public List<FactionSerializableData> factionData;
        public List<TurfNodeSerializableData> turfNodeData;
        public string timestamp;
    }
}
