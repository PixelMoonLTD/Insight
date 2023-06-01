using UnityEngine;
using UnityEngine.Pool;

namespace Enemies.Scripts
{
    /// <summary>
    /// Manages a pool of enemy objects, utilising Unity's built-in object pooling API.
    /// </summary>
    public class EnemyPool : MonoBehaviour
    {
        public IObjectPool<Enemy> Pool
        {
            get
            {
                if (_pool == null)
                {
                    _pool = new ObjectPool<Enemy>(CreatedPooledItem, OnTakeFromPool, OnReturnedToPool, 
                        OnDestroyPoolObject, true, defaultStackCapacity, maxPoolSize);
                }
                return _pool;
            }
        }
        
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int maxPoolSize;
        [SerializeField] private int amountToPreallocate;
        [SerializeField] private int defaultStackCapacity;
        private IObjectPool<Enemy> _pool;

        private void Awake()
        {
            PreallocateEnemyObjects();
        }

        /// <summary>
        /// Called when there are no items available in the pool and so one must be created
        /// </summary>
        /// <returns></returns>
        private Enemy CreatedPooledItem()
        {
            var enemyObject = Instantiate(enemyPrefab);
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemy.SetPool(Pool);
            return enemy;
        }
        
        /// <summary>
        /// Called when an item is returned to the pool using pool.Release()
        /// </summary>
        private void OnReturnedToPool(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }
        
        /// <summary>
        /// Called when an item is taken from the pool using pool.Get()
        /// </summary>
        private void OnTakeFromPool(Enemy enemy)
        {
            enemy.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Called when an item is attempted to be taken from the pool but the pool capacity has been reached
        /// </summary>
        private void OnDestroyPoolObject(Enemy enemy)
        {
            Destroy(enemy.gameObject);
        }
        
        /// <summary>
        /// Pre-instantiates enemy objects on play, and returns them to the pool ready to be used
        /// </summary>
        private void PreallocateEnemyObjects()
        {
            for (int i = 0; i < amountToPreallocate; i++)
            {
                var enemy = CreatedPooledItem();
                enemy.transform.SetParent(transform);

                // return pre-allocated enemies back to the pool
                _pool.Release(enemy);
            }
        }
    }
}
