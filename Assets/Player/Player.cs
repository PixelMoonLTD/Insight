using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    private Vector2 movementInput;

    private Vector2 pointerInput;

    [SerializeField]
    private GameObject[] bulletObject;

    private GameObject selectedBullet;

    private int health = 100;

    [SerializeField]
    private InputActionReference _movement, _attack, _pointer;

    [SerializeField]
    private WeaponParentController weaponParent;

    [SerializeField]
    private PlayerMover mover;

    public int CurrentHealth { get; set; }

    private void OnEnable()
    {
        _attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        _attack.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        //pull bullet from pool here (ask charlie how it's coming along)
        GameObject bullet = Instantiate(selectedBullet, weaponParent.weaponPos.transform.position, Quaternion.identity);
        bullet.GetComponent<Projectile>().SetShootDirection(transform.position, pointerInput);
    }


    private void Start()
    {
        selectedBullet = bulletObject[0];
    }

    private void Update()
    {
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
#endif
        pointerInput = GetPointerPosition();

        weaponParent.PointerPos = pointerInput;

        movementInput = _movement.action.ReadValue<Vector2>();

        mover._movementInput = movementInput;
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
