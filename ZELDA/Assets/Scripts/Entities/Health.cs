using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    public int maxLife;
    public float currentLife;

    private void Start()
    {
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
        Destroy(gameObject);
    }
}
