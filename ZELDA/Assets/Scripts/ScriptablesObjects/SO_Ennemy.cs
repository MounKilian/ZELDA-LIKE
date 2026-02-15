using UnityEngine;


[CreateAssetMenu(fileName = "NewEnnemi", menuName = "Data/Ennemi", order = 1)]
public class SO_Ennemy : ScriptableObject
{
    public int health;
    public float speed;
    public int dammage;
    public float attackCooldown;
}
