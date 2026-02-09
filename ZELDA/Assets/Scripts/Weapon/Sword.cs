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
        Debug.Log("Sword hit");
    }
}
