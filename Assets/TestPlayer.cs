using Interfaces;
using UnityEngine;

/// <summary>
/// TEMPORARY player class for testing enemy functionality with
/// </summary>
public class TestPlayer : MonoBehaviour, IDamageable
{
    public int CurrentHealth { get; set; }
    private const int Damage = 100;
    
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        IDamageable hit = col.gameObject.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.TakeDamage(Damage);
        }
    }
}
