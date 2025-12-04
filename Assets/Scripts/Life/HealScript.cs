using UnityEngine;

public class HealScript : MonoBehaviour
{
    [SerializeField]
    private float healAmount = 5f; // Cantidad de curación

    void OnTriggerEnter(Collider other)
    {
        HealthScript health = other.GetComponent<HealthScript>();
        if (health != null)
        {
            health.Heal(healAmount); // Curar al objeto
            Destroy(gameObject); // Destruir el objeto de curación
        }
    }
}