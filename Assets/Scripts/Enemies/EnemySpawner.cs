using Enemies.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private int amountToSpawn = 20;
        [SerializeField] private float spawnRate = 1.0f;
        [SerializeField] int spawnCap = 20;
        

        private void Start()
        {
            
            InvokeRepeating(nameof(SpawnEnemy), 1.0f, spawnRate);
        }

        private void SpawnEnemy()
        {
            if (enemyPool.amountSpawned < spawnCap - amountToSpawn)
            {
                for (int i = 0; i < amountToSpawn; i++)
                {
                    var enemy = enemyPool.Pool.Get();
                    enemy.transform.SetParent(transform);
                    enemy.transform.position = RandomSpawnPosition();
                }
            }
        }

        private Vector2 RandomSpawnPosition()
        {
            return Random.insideUnitCircle * 8f;
        }
    }
}
