using Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Enemies.Scripts
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public int CurrentHealth { get; set; }
        public EnemyData Data => enemyData;
        
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private GameObject damagePopupPrefab;
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
            var go = Instantiate(damagePopupPrefab, transform.position, Quaternion.identity);
            go.GetComponent<DamagePopup>().SetDamageText(amount);

            if (CurrentHealth <= 0)
                Die();
        }
        
        private void ResetEnemy()
        {
            CurrentHealth = enemyData.health;
        }

        private void Die()
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