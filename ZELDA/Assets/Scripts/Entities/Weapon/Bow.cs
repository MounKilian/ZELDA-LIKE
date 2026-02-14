using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;

    private void OnEnable()
    {
        Instantiate(arrow, transform.position, transform.rotation);
    }
}
