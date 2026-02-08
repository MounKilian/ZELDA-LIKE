using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Référence")]
    public InputActionAsset action;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    [Header("Life UI")]
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Image[] lifeImages;

    [Header("Settings")]
    public float speed = 150f;
    public int maxLife = 6;
    public int currentLife;

    private Vector2 dir;

    void Start()
    {
        currentLife = maxLife;
        LifeUIUpdate();

        var map = action.FindActionMap("Player");
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

    private void Update()
    {
        if (dir.x < 0)
        {
            sprite.flipX = true;
        } else
        {
            sprite.flipX = false;
        }
    }

    private void LifeUIUpdate()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (currentLife >= (i + 1) * 2)
            {
                lifeImages[i].sprite = fullHeart;
            }
            else if (currentLife == (i * 2) + 1)
            {
                lifeImages[i].sprite = halfHeart;
            }
            else
            {
                lifeImages[i].sprite = emptyHeart;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentLife -= amount;

        LifeUIUpdate();

        if (currentLife <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Dead");
    }

}
