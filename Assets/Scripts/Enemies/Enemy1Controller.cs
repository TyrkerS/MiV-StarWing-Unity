using UnityEngine;
using System.Collections;

public class Enemy1Controller : MonoBehaviour
{
    [SerializeField]
    private Transform target; // Objetivo al que se dirige el disparo
    [SerializeField]
    private GameObject bulletPrefab; // Prefab de la bala a instanciar
    [SerializeField]
    private Transform firePoint; // Punto donde se instanciará la bala
    [SerializeField]
    private float attackSpeed = 1f; // Tiempo entre disparos (velocidad de ataque)
    [SerializeField]
    private float damage = 10f; // Daño que inflige cada bala
    [SerializeField]
    private float moveDelay = 2f; // Tiempo que el enemigo espera antes de disparar
    [SerializeField]
    private float moveSpeed = 5f; // Velocidad de movimiento hacia la nueva posición

    [SerializeField]
    private Vector2 xRange = new Vector2(-28f, 28f);
    [SerializeField]
    private Vector2 yRange = new Vector2(0f, 25f);
    [SerializeField]
    private Vector2 zRange = new Vector2(15f, 35f);

    private float nextShotTime = 0f; // Control del tiempo entre disparos

    private void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
            else
            {
                Debug.LogError("No se encontró un objeto con la etiqueta 'Player'.");
            }
        }
        StartCoroutine(EnemyRoutine());
    }

    private IEnumerator EnemyRoutine()
    {
        while (true)
        {
            // Mover el enemigo a una nueva posición aleatoria
            yield return StartCoroutine(MoveToRandomPosition());

            // Esperar un momento antes de disparar
            yield return new WaitForSeconds(moveDelay);

            // Disparar un número aleatorio de veces entre 1 y 5
            int shots = Random.Range(1, 6);
            for (int i = 0; i < shots; i++)
            {
                ShootAtTarget();
                yield return new WaitForSeconds(attackSpeed); // Esperar entre disparos
            }
        }
    }

    private void ShootAtTarget()
    {
        if (Time.time >= nextShotTime && target != null)
        {
            // Calcular la dirección hacia el objetivo
            Vector3 direction = (target.position - firePoint.position).normalized;

            // Instanciar la bala
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Configurar la dirección y el daño de la bala
            ScriptShootEnemy bulletScript = bullet.GetComponent<ScriptShootEnemy>();
            if (bulletScript != null)
            {
                bulletScript.SetDamage(damage);
                bulletScript.SetDirection(direction);
            }

            // Establecer el próximo tiempo de disparo
            nextShotTime = Time.time + attackSpeed;
        }
    }

    private IEnumerator MoveToRandomPosition()
    {
        // Generar una nueva posición aleatoria
        float newX = Random.Range(xRange.x, xRange.y);
        float newY = Random.Range(yRange.x, yRange.y);
        float newZ = Random.Range(zRange.x, zRange.y);
        Vector3 targetPosition = new Vector3(newX, newY, newZ);

        // Mover gradualmente al enemigo hacia la nueva posición
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Enemy moved to: " + transform.position);
    }
}