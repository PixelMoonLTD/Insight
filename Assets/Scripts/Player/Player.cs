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
    [Header("STATS")]
    [SerializeField]
    PlayerStats stats;

    [Header("UI")]
    [SerializeField]
    Slider bar;

    private Vector2 movementInput;

    private Vector2 pointerInput;

    [Header("Variables")]

    [SerializeField]
    private GameObject selectedBullet;

    private int health;

    [SerializeField]
    private InputActionReference _movement, _attack, _pointer;

    [SerializeField]
    private WeaponParentController weaponParent;

    [SerializeField]
    private PlayerMover mover;

    private float fire_rate;

    /*private Light2D;*/

    public int CurrentHealth { get; set; }


    private void Start()
    {
        health = stats.max_health;
        fire_rate = 16/stats.fire_rate;

        bar.maxValue = fire_rate;
        bar.value = 0;
    }

    private void Update()
    {
        fire_rate -= Time.deltaTime;
        bar.value += Time.deltaTime;

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
            fire_rate = 16 / stats.fire_rate;
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

    //need to change so it knows what stat is being passed in
    public void IncreasePlayerStat(PlayerStats stat)
    {
        //+= for ones that are int, *= for those that are floats (standard increase vs % increase)
        stats.max_health += stat.max_health;
        stats.fire_rate *= stat.fire_rate;
        stats.movement_speed *= stat.movement_speed;
        stats.critical_rate += stat.critical_rate;
        stats.damage *= stat.damage;
        stats.shoot_speed *= stat.shoot_speed;
        stats.elemental_damage += stat.elemental_damage;
             
        bar.maxValue = 16 / stats.fire_rate;
    }

    public void ChangeBulletType(GameObject bulletID)
    {
        selectedBullet = bulletID;
    }

    public PlayerStats GetStats()
    {
        return stats;
    }
}
