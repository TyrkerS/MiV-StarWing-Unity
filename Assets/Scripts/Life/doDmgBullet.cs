using UnityEngine;

public class doDmgBullet : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f; // DaÃ±o que la bala aplica

    private ScriptShoPowerUp powerUpScript;

    void Start()
    {
        powerUpScript = FindAnyObjectByType<ScriptShoPowerUp>();
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Colision detectada");

        HealthScript health = collision.gameObject.GetComponent<HealthScript>();
        if (health != null)
        {
            health.TakeDamage(damage);

            if (powerUpScript != null)
            {
                powerUpScript.AddDamage(damage);
            }
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        print("Colision detectada con: " + other.gameObject.name);
        Destroy(gameObject);
    }
}
