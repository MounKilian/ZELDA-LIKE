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

    void Update()
    {
        LifeUIUpdate();
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
}
