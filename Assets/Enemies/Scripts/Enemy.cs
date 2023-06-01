using Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Enemies.Scripts
{
    /// <summary>
    /// Base class that all enemies should inherit methods and functionality from. 
    /// </summary>
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        public int CurrentHealth { get; set; }
        
        [SerializeField] private EnemyData enemyData;
        private IObjectPool<Enemy> _pool;
        
        /// <summary>
        /// Resets the enemy back to it's starting state when disabled so that
        /// it is ready to be reused when re-obtained from an object pool. 
        /// </summary>
        private void OnDisable()
        {
            ResetEnemy();
        }

        private void Start()
        {
            CurrentHealth = enemyData.health;
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;

            if (CurrentHealth <= 0)
                Die();
        }
        
        protected virtual void ResetEnemy()
        {
            CurrentHealth = enemyData.health;
        }

        protected virtual void Die()
        {
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            _pool.Release(this);
        }

        public void SetPool(IObjectPool<Enemy> pool)
        {
            _pool = pool;
        }
    }
}