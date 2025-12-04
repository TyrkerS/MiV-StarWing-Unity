using UnityEngine;

public class doDmgPowerUp : MonoBehaviour
{
    private float explosionRadius;
    private int explosionDamage;

    public void Initialize(float radius, int damage)
    {
        explosionRadius = radius;
        explosionDamage = damage;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Mensaje para depuraciÃ³n
        print("ColisiÃ³n de power-up detectada");

        // Obtener el componente HealthScript del objeto impactado
        HealthScript health = collision.gameObject.GetComponent<HealthScript>();

        // Si el objeto impactado tiene un componente HealthScript
        if (health != null)
        {
            // Aplicar daÃ±o al objeto impactado
            health.TakeDamage(explosionDamage);
        }

        // Crear explosion en direcciÃ³n hacia adelante
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in hitColliders)
        {
            // Verificar si el objeto estÃ¡ dentro del cono hacia adelante
            Vector3 directionToTarget = (hit.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, directionToTarget);

            if (angle <= 90.0f) // Ãngulo de 90 grados hacia adelante
            {
                HealthScript areaHealth = hit.GetComponent<HealthScript>();
                if (areaHealth != null)
                {
                    // Aplicar daÃ±o en el Ã¡rea hacia adelante
                    areaHealth.TakeDamage(explosionDamage);
                }
            }
        }

        // Destruir el proyectil tras impactar
        Destroy(gameObject);
    }
}