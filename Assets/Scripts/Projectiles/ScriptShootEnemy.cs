using UnityEngine;

public class ScriptShootEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f; // Velocidad de la bala
    [SerializeField]
    private float damage;
    [SerializeField]
    private float lifetime = 5f; // Tiempo de vida del proyectil antes de destruirse automáticamente

    private Vector3 targetDirection;

    public void SetDamage(float value)
    {
        damage = value;
    }

    public void SetDirection(Vector3 direction)
    {
        targetDirection = direction.normalized; // Asegura que la dirección esté normalizada
    }

    private void Start()
    {
        // Destruir el proyectil automáticamente después de su tiempo de vida
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Mover la bala en la dirección establecida
        transform.position += targetDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
{
    HealthScript health = other.GetComponent<HealthScript>();
    if (health != null)
    {
        health.TakeDamage(damage);
    }
    Destroy(gameObject); // Destruir la bala después del impacto
}
}