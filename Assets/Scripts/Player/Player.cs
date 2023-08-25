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
    private GameObject[] bulletObject;

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
        fire_rate = 12/stats.fire_rate;

        selectedBullet = bulletObject[0];

        bar.maxValue = fire_rate;
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
            fire_rate = 12 / stats.fire_rate;
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

    public void IncreaseMaxHealth(int amount)
    {
        stats.max_health += stats.max_health * amount;
    }

    public void IncreaseFireRate()
    {
        stats.fire_rate += 2;
        
    }

    //need to change so it knows what stat is being passed in
    public void IncreasePlayerStat(PlayerStats stat, UpgradeTier tier)
    {
        switch (tier)
        {
            case UpgradeTier.COMMON:
                stat.fire_rate = stat.fire_rate * 1.01f;
                break;
            case UpgradeTier.RARE:
                stat.fire_rate = stat.fire_rate * 1.025f;
                break;
            case UpgradeTier.LEGENDARY:
                stat.fire_rate = stat.fire_rate * 1.04f;
                break;
        }
        bar.maxValue = 12 / stats.fire_rate;
    }

    public PlayerStats GetStats()
    {
        return stats;
    }
}
