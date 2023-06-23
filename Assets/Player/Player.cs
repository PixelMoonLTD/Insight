using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 movementInput;

    private Vector2 pointerInput;

    [SerializeField]
    private GameObject bulletObject;


    [SerializeField]
    private InputActionReference _movement, _attack, _pointer;

    [SerializeField]
    private WeaponParentController weaponParent;

    [SerializeField]
    private PlayerMover mover;

    [SerializeField]
    private GameObject lightSource;

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
        GameObject bullet = Instantiate(bulletObject, weaponParent.weaponPos.transform.position, Quaternion.identity);
        bullet.GetComponent<Projectile>().SetShootDirection(transform.position, pointerInput);
    }


    private void Start()
    {
        
    }

    private void Update()
    {
        pointerInput = GetPointerPosition();

        weaponParent.PointerPos = pointerInput;

        Vector2 direction = (pointerInput - (Vector2)lightSource.transform.position).normalized;
        lightSource.transform.up = direction;

        movementInput = _movement.action.ReadValue<Vector2>();

        mover._movementInput = movementInput;
    }

    private Vector2 GetPointerPosition()
    {
        Vector3 mousePos = _pointer.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
