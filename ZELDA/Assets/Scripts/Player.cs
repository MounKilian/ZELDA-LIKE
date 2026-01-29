using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Référence")]
    public InputActionAsset action;
    public Rigidbody2D rb;

    [Header("Settings")]
    public float speed = 150f;
    
    private Vector2 dir;

    void Start()
    {
        var map = action.FindActionMap("PLayer");
        var move = map.FindAction("Move");

        move.started += OnMove;
        move.performed += OnMove;
        move.canceled += OnMove;

        action.Enable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = dir * speed * Time.fixedDeltaTime;
    }
}
