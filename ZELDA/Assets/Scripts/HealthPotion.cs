using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [Header("Référence")]
    public SO_HealthPotion stats;

    [Header("Player Référence")]
    public GameObject player;

    [Header("Inventory Référence")]
    public Inventory inventory;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!stats.isBig)
            {
                player.GetComponent<Player>().inventory.AddHealthPotion();
            } else
            {
                player.GetComponent<Player>().inventory.AddBigHealthPotion();
            }

            Destroy(gameObject);
        }
    }
}
