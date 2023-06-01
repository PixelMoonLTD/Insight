using UnityEngine;

namespace Enemies.Scripts
{
    [CreateAssetMenu(menuName = "Custom/Enemies/Enemy Data", fileName = "NewEnemyData")]
    public class EnemyData : ScriptableObject
    {
        public string enemyName;
        [field: TextArea] public string enemyDescription;
        public GameObject enemyPrefab;
        public int health;
        public int damage;
        public int speed;
    }
}
