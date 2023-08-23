using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    PlayerStats stats;

    [SerializeField]
    Slider bar;

    private Vector2 movementInput;

    private Vector2 pointerInput;

    [SerializeField]
    private GameObject[] bulletObject;

    private GameObject selectedBullet;

    private int health;

    [SerializeField]
    private InputActionReference _movement, _attack, _pointer;

    [SerializeField]
    private WeaponParentController weaponParent;

    [SerializeField]
    private PlayerMover mover;

    private float fire_rate = 2f;

    /*private Light2D;*/

    public int CurrentHealth { get; set; }


    private void Start()
    {
        health = stats.max_health;

        selectedBullet = bulletObject[0];

        bar.value = 0;
    }

    private void Update()
    {
        fire_rate -= Time.deltaTime;
        bar.value += Time.deltaTime;

#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBullet = bulletObject[0];
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedBullet = bulletObject[1];
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedBullet = bulletObject[2];
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedBullet = bulletObject[3];
        }
#endif
        pointerInput = GetPointerPosition();

        weaponParent.PointerPos = pointerInput;

        movementInput = _movement.action.ReadValue<Vector2>();

        mover._movementInput = movementInput;

        if(fire_rate <= 0)
        {
            ///pull bullet from pool here (ask charlie how it's coming along)
            ///add fire rate limiter
            GameObject bullet = Instantiate(selectedBullet, weaponParent.weaponPos.transform.position, Quaternion.identity);
            bullet.GetComponent<Projectile>().SetShootDirection(transform.position, pointerInput);
            fire_rate = 2.0f;
            bar.value = 0;
        }

    }

    private Vector2 GetPointerPosition()
    {
        Vector3 mousePos = _pointer.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }
}
