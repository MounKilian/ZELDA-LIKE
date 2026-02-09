using UnityEngine;
using UnityEngine.U2D;

public class Arrow : MonoBehaviour
{
    public float speed = 400f;
    public Rigidbody2D rb;
    public Vector2 dir;
    public Player player;

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
    }
}
