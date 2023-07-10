using UnityEngine;

namespace Enemies.Scripts
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMovement : MonoBehaviour
    {
        private EnemyData _enemyData;
        private Transform _target;

        private void Awake() => _enemyData = GetComponent<Enemy>().Data;

        private void Update()
        {
            if (_target == null)
                return;

            transform.position = Vector2.MoveTowards(transform.position, _target.position, _enemyData.speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                _target = col.transform;
            }
        }
    }
}