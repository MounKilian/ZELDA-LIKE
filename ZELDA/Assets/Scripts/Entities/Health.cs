using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Player Référence")]
    public Player player;

    [Header("Settings")]
    public int maxLife;
    public int currentLife;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentLife = maxLife;
    }

    public void TakeDamage(int amount)
    {
        currentLife -= amount;

        if (currentLife <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentLife += amount;

        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
    }

    void Die()
    {
        if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Dead");
        }
        else
        {
            player.killCount++;
            Destroy(gameObject);

            if (player.killCount >= 6)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
