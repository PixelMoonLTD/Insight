using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageType
{
    [SerializeField]
    IDamageType.DamageType damageType;

    Rigidbody2D rb2d;

    [SerializeField]
    float damage = 10f;

    [SerializeField]
    float elementalDamage = 0f;

    [SerializeField]
    float speed = 5f;

    Vector2 shootDir = new Vector2();

    public void SetShootDirection(Vector2 shooter_pos, Vector2 mouse_pos)
    {
        shootDir = mouse_pos - shooter_pos;
        shootDir.Normalize();
    }


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 3.5f);
    }

    void FixedUpdate()
    {
        rb2d.velocity = shootDir * speed * Time.deltaTime;

        if (speed > 80)
        {
            speed -= .75f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            float rand = Random.Range(1, 64);

            float damage_calc = 0f;

            damage_calc = ((damage * speed) + elementalDamage) / 85;

            if(checkWeakness(collision.gameObject.GetComponent<Enemies.Scripts.Enemy>().weaknesses))
            {
                damage_calc *= 2;
            }

            if(rand >= 60)
            {
                damage_calc *= 1.5f;
                collision.gameObject.GetComponent<Enemies.Scripts.Enemy>().CallCriticalText();
            }

            collision.gameObject.GetComponent<Enemies.Scripts.Enemy>().TakeDamage((int)damage_calc);

            Destroy(gameObject);
        }
    }

    bool checkWeakness(IDamageType.DamageType incomingDamage)
    {
        return (damageType & incomingDamage) != 0;
    }
}
