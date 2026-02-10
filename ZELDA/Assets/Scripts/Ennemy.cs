using UnityEngine;
using UnityEngine.U2D;

public class Ennemy : MonoBehaviour
{
    public SO_Ennemy stats;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    public Vector2 dir;

    private float currentHealth;

    void Start()
    {
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        dir = (player.transform.position - transform.position).normalized;

        rb.linearVelocity = dir * stats.speed * Time.fixedDeltaTime;
    }
}
