using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// TEMPORARY player class for testing enemy functionality with
/// </summary>
public class TestPlayer : MonoBehaviour, IDamageable
{
    public int CurrentHealth { get; set; }
    private int _damage;

    private void Start() => _damage = Random.Range(50, 101);

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out IDamageable damageable))
        {
            _damage = Random.Range(50, 101);
            damageable.TakeDamage(_damage);
        }
    }
}
