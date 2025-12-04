using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; // Prefab del enemigo a instanciar
    [SerializeField]
    private Vector3 spawnPosition = new Vector3(0, 10, 120); // Posición donde se spawneará el enemigo

    private GameObject currentEnemy; // Referencia al enemigo actual

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            HealthScript healthScript = currentEnemy.GetComponent<HealthScript>();

            if (healthScript != null)
            {
                StartCoroutine(CheckEnemyHealth(healthScript));
            }

            Debug.Log("Enemigo spawneado en: " + spawnPosition);
        }
        else
        {
            Debug.LogError("El prefab del enemigo no está asignado.");
        }
    }

    private System.Collections.IEnumerator CheckEnemyHealth(HealthScript healthScript)
    {
        while (healthScript != null)
        {
            yield return null; // Esperar al siguiente frame
        }

        Debug.Log("Enemigo eliminado. Spawneando uno nuevo...");
        SpawnEnemy();
    }
}
