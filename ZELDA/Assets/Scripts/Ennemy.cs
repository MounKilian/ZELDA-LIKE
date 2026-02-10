using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Ennemy : MonoBehaviour
{
    [Header("Référence")]
    public SO_Ennemy stats;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public GameObject player;

    [Header("Settings")]
    public Vector2 dir;
    private float currentHealth;
    public float detectionRange = 5f;
    public int walk = 0;
    private bool canFollow = false;
    private bool isTouchingPlayer = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        currentHealth = stats.health;
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    private void Update()
    {
        if (dir.x != 0)
        {
            if (dir.x < 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
    }

    void FollowPlayer()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (isTouchingPlayer)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (distance <= detectionRange)
        {
            canFollow = true;
        }

        if (!canFollow)
        {
            if (walk > 100)
            {
                dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                walk = 0;
            }
            walk++;
        } 
        else
        {
            dir = (player.transform.position - transform.position).normalized;
        };

        rb.linearVelocity = dir * stats.speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = true;
            Debug.Log("Ghost hit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }
}
