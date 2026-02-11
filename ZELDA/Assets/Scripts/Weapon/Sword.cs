using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    [Header("Référence")]
    public SpriteRenderer sprite;

    [Header("Settings")]
    public int dammage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(dammage);
        }
    }
}
