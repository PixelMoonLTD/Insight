using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rb2d;

    
    private float maxSpeed, acceleration = 10, decceleration = 20;

    private float currentSpeed = 0;

    public Vector2 _movementInput { get; set; }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        maxSpeed = GetComponent<Player>().GetStats().movement_speed;
    }

    private void FixedUpdate()
    {
        if(_movementInput.magnitude > 0 && currentSpeed >= 0)
        {
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= decceleration * maxSpeed * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb2d.velocity = _movementInput * currentSpeed;
    }
}
