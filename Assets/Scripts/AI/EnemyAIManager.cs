using UnityEngine;
using System.Collections.Generic;
using AsphaltAnarchy.Factions;

namespace AsphaltAnarchy.AI
{
    /// <summary>
    /// Manages all enemy AI instances and global fear level updates.
    /// </summary>
    public class EnemyAIManager : MonoBehaviour
    {
        [Header("Spawn Pools")]
        [SerializeField] private List<GameObject> enemyPrefabs;
        [SerializeField] private List<Transform> spawnPoints;
        [SerializeField] private int maxActiveEnemies = 20;

        private List<EnemyAI> activeEnemies = new List<EnemyAI>();
        private int globalFearLevel;

        public void RegisterEnemy(EnemyAI enemy)
        {
            if (!activeEnemies.Contains(enemy))
                activeEnemies.Add(enemy);
        }

        public void UnregisterEnemy(EnemyAI enemy)
        {
            activeEnemies.Remove(enemy);
        }

        public List<EnemyAI> GetActiveEnemies()
        {
            return new List<EnemyAI>(activeEnemies);
        }

        public void UpdateGlobalFearLevel(int echoLevel)
        {
            globalFearLevel = echoLevel;

            foreach (var enemy in activeEnemies)
            {
                // Force state re-evaluation
                // The enemy's UpdateFearLevel will pick up the new Echo level next frame
            }
        }

        public List<EnemyAI> SpawnEnemyWave(FactionData faction, Vector3 location, int count)
        {
            var spawned = new List<EnemyAI>();

            for (int i = 0; i < count; i++)
            {
                if (activeEnemies.Count >= maxActiveEnemies) break;

                Vector3 spawnPos = location + Random.insideUnitSphere * 20f;
                spawnPos.y = location.y;

                var prefab = faction?.bikePrefab ?? enemyPrefabs[0];
                var instance = Instantiate(prefab, spawnPos, Quaternion.identity);
                var enemyAI = instance.GetComponent<EnemyAI>();
                if (enemyAI != null)
                {
                    // Faction identity comes from the prefab itself (each faction's
                    // bikePrefab has its own FactionData pre-set on EnemyAI), not a
                    // runtime setter.
                    RegisterEnemy(enemyAI);
                    spawned.Add(enemyAI);
                }
            }

            return spawned;
        }

        public void ClearAllEnemies()
        {
            foreach (var enemy in activeEnemies)
            {
                if (enemy != null)
                    Destroy(enemy.gameObject);
            }
            activeEnemies.Clear();
        }
    }
}
