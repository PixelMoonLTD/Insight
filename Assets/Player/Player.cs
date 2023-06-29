using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour, IDamageable
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

    [SerializeField]
    private Light2D lightComponent;

    private int health = 500;

    float maxTargetInten;
    float minTargetInten;
    float targetInten;

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
        GameObject bullet = Instantiate(bulletObject, weaponParent.weaponPos.transform.position, Quaternion.identity);
        bullet.GetComponent<Projectile>().SetShootDirection(transform.position, pointerInput);
    }


    private void Start()
    {
        lightComponent.intensity = 15;
        CurrentHealth = health;
        targetInten = minTargetInten;
    }

    private void Update()
    {
        pointerInput = GetPointerPosition();

        weaponParent.PointerPos = pointerInput;

        Vector2 direction = (pointerInput - (Vector2)lightSource.transform.position).normalized;
        lightSource.transform.up = direction;

        movementInput = _movement.action.ReadValue<Vector2>();

        mover._movementInput = movementInput;

        if (CurrentHealth <= 100 && CurrentHealth > 0)
        {
            if (isApproximate(lightComponent.intensity, maxTargetInten, 0.1f))
            {
                targetInten = minTargetInten;
            }

            if (isApproximate(lightComponent.intensity, minTargetInten, 0.1f))
            {
                targetInten = maxTargetInten;
            }

            lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, targetInten, 1.5f * Time.deltaTime);
        }


#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            TakeDamage(50);
            //Debug.Log(CurrentHealth);
        }
#endif
    }

    private Vector2 GetPointerPosition()
    {
        Vector3 mousePos = _pointer.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;

        lightComponent.intensity = (CurrentHealth / (float)health) * 15;
        maxTargetInten = lightComponent.intensity + 1.5f;
        minTargetInten = lightComponent.intensity - 1.5f;

        if (CurrentHealth <= 200)
        {
            lightComponent.color = new Color((255 - CurrentHealth), 0, 0, .05f);
        }
    }

    bool isApproximate(float a, float b, float tolerance)
    {
        return Mathf.Abs(a - b) < tolerance;
    }
}
