using UnityEngine;
using UnityEngine.U2D;

public class Arrow : MonoBehaviour
{
    [Header("Référence")]
    public Rigidbody2D rb;
    public Player player;

    [Header("Settings")]
    public int dammage = 1;
    public float speed = 400f;
    public Vector2 dir;

    private void OnEnable()
    {
        dir = player.lastDir;

        if (dir.x < 0)
        {
            dir = new Vector2(-1f, 0f);
            transform.localRotation = Quaternion.Euler(0, 0, 135);
        }
        else
        {
            dir = new Vector2(1f, 0f);
            transform.localRotation = Quaternion.Euler(0, 0, -45);
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = dir * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Arrow hit");
        Destroy(gameObject);
    }
}
