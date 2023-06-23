using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private enum lightIntensity { Increasing, Decreasing }
    lightIntensity light_intensity;

    Rigidbody2D rb2d;

    [SerializeField]
    float damage = 10f;
    [SerializeField]
    float speed = 5f;

    private Light2D light;

    Vector2 shootDir = new Vector2();

    public void SetShootDirection(Vector2 shooter_pos, Vector2 mouse_pos)
    {
        shootDir = mouse_pos - shooter_pos;
        shootDir.Normalize();
    }


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        light = transform.GetChild(0).GetComponent<Light2D>();
    }

    void FixedUpdate()
    {
        rb2d.velocity = shootDir * speed * Time.deltaTime;

        if (speed > 80)
        {
            speed -= .75f;
        }

        if(light.intensity >= 25)
        {
            light_intensity = lightIntensity.Decreasing;
        }
        if(light.intensity <= 15)
        {
            light_intensity = lightIntensity.Increasing;
        }

        if(light_intensity == lightIntensity.Decreasing)
        {
            light.intensity -= 0.85f;
        }

        if(light_intensity == lightIntensity.Increasing)
        {
            light.intensity += 0.85f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemies.Scripts.Enemy>().TakeDamage((int)(damage * speed/75));
            Debug.Log(damage * (speed/75));

            Destroy(gameObject);
        }
    }
}
