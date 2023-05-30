using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 movementInput;

    private Vector2 pointerInput;

    [SerializeField]
    private InputActionReference _movement, _attack, _pointer;

    [SerializeField]
    private PlayerMover mover;

    /*private void Start()
    {
        
    }*/

    private void Update()
    {
        pointerInput = GetPointerPosition();

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
