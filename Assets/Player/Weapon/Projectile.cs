using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    float damage = 10f;
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
    }

    void FixedUpdate()
    {
        rb2d.velocity = shootDir * speed * Time.deltaTime;
        /*if(isActiveAndEnabled)
        {
            rb2d.velocity = shootDir * speed;
        }*/
    }
}
