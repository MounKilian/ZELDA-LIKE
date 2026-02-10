using System;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Référence")]
    public InputActionAsset action;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    [Header("Weapon Settings")]
    public Sword sword;
    public Vector3 swordRightPos = new Vector3(0.3f, -0.28f, 0); 
    public Vector3 swordLeftPos = new Vector3(-0.3f, -0.28f, 0); 

    public Bow bow;
    public Vector3 bowRightPos = new Vector3(0.57f, -0.11f, 0);
    public Vector3 bowLeftPos = new Vector3(-0.57f, -0.11f, 0);

    public float attackCooldown = 1f;
    public float attackTimer = 0f;

    [Header("Life UI")]
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Image[] lifeImages;

    [Header("Settings")]
    public float speed = 150f;
    public int maxLife = 6;
    public float currentLife;

    public Vector2 dir;
    public Vector2 lastDir;

    void Start()
    {
        currentLife = maxLife;
        LifeUIUpdate();

        var map = action.FindActionMap("Player");
        var move = map.FindAction("Move");
        var attackSword = map.FindAction("Attack");
        var attackBow = map.FindAction("AttackProjectile");

        move.started += OnMove;
        move.performed += OnMove;
        move.canceled += OnMove;

        attackSword.started += OnAttackSword;
        attackSword.canceled += OnAttackSword;

        attackBow.started += OnAttackBow;
        attackBow.canceled += OnAttackBow;

        action.Enable();
        sword.gameObject.SetActive(false);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
    }

    private void OnAttackSword(InputAction.CallbackContext context)
    {
        if (!bow.gameObject.activeSelf)
        {
            sword.gameObject.SetActive(context.ReadValueAsButton());
        }
    }

    private void OnAttackBow(InputAction.CallbackContext context)
    {
        if (context.started && attackTimer >= attackCooldown)
        {
            if (!sword.gameObject.activeSelf)
            {
                attackTimer = 0f;
                bow.gameObject.SetActive(true);
            }
        }
        if (context.canceled)
        {
            bow.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = dir * speed * Time.fixedDeltaTime;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (dir.x != 0)
        {
            lastDir = dir;
            if (dir.x < 0)
            {
                sword.transform.localPosition = swordLeftPos;
                sword.transform.localRotation = Quaternion.Euler(0, 0, 90);

                bow.transform.localPosition = bowLeftPos;
                bow.transform.localRotation = Quaternion.Euler(0, 0, 180);

                sprite.flipX = true;
            }
            else
            {
                sword.transform.localPosition = swordRightPos;
                sword.transform.localRotation = Quaternion.Euler(0, 0, -90);

                bow.transform.localPosition = bowRightPos;
                bow.transform.localRotation = Quaternion.Euler(0, 0, 0);

                sprite.flipX = false;
            }
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
