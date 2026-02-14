using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Health Référence")]
    public Health health;

    [Header("Life UI")]
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Image[] lifeImages;

    [Header("Inventory Référence")]
    public Inventory inventory;

    [Header("Inventory UI")]
    public Image healthPotion;
    public Image bigHealthPotion;
    public TextMeshProUGUI healthPotionText;
    public TextMeshProUGUI bigHealthPotionText;

    void Start()
    {
        healthPotion.enabled = false;
        healthPotionText.enabled = false;
        bigHealthPotion.enabled = false;
        bigHealthPotionText.enabled = false;
    }

    void Update()
    {
        LifeUIUpdate();
        InventoryUIUpdate();
    }

    private void LifeUIUpdate()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (health.currentLife >= (i + 1) * 2)
            {
                lifeImages[i].sprite = fullHeart;
            }
            else if (health.currentLife == (i * 2) + 1)
            {
                lifeImages[i].sprite = halfHeart;
            }
            else
            {
                lifeImages[i].sprite = emptyHeart;
            }
        }
    }

    private void InventoryUIUpdate()
    {
        if (inventory.healthPotionCount > 0)
        {
            healthPotion.enabled = true;
            healthPotionText.enabled = true;
        }

        if (inventory.bigHealthPotionCount > 0)
        {
            bigHealthPotion.enabled = true;
            bigHealthPotionText.enabled = true;
        }

        healthPotionText.text = inventory.healthPotionCount.ToString();
        bigHealthPotionText.text = inventory.bigHealthPotionCount.ToString();
    }
}
