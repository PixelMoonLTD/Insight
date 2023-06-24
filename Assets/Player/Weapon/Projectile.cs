using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageType
{
    [SerializeField]
    IDamageType.DamageType damageType = IDamageType.DamageType.NONE;

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
            collision.gameObject.GetComponent<Enemies.Scripts.Enemy>().TakeDamage((int)(damage + elementalDamage * speed/75));
            //collision.gameObject.transform.position = Vector3.Lerp(collision.gameObject.transform.position, collision.gameObject.transform.position + (Vector3)rb2d.velocity, .5f);
            //Debug.Log(damage * (speed/75));

            Destroy(gameObject);
        }
    }
}
