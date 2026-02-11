using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [Header("Référence")]
    public SO_HealthPotion stats;
    public GameObject player;

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
                player.GetComponent<Player>().healthPotionCount++;
            } else
            {
                player.GetComponent<Player>().bigHealthPotionCount++;
            }

            Destroy(gameObject);
        }
    }
}
