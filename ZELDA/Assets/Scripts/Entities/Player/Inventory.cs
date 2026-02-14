using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Settings")]
    public int healthPotionCount = 0;
    public int bigHealthPotionCount = 0;

    public void AddHealthPotion()
    {
        healthPotionCount++;
    }

    public void AddBigHealthPotion()
    {
        bigHealthPotionCount++;
    }

    public void SubstractHealthPotion()
    {
        healthPotionCount--;
    }

    public void SubstractBigHealthPotion()
    {
        bigHealthPotionCount--;
    }
}
