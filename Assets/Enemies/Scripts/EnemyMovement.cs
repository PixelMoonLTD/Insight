using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyData enemyData;
        private Transform _target;

        private void Awake() => _target = GameObject.FindWithTag("Player").transform; // TODO: Clean

        private void Update()
        {
            if (_target == null)
                return;

            transform.position = Vector2.MoveTowards(transform.position, _target.position, enemyData.speed * Time.deltaTime);
        }
    }
}