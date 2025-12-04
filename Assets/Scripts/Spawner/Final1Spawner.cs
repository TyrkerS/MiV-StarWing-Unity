using UnityEngine;

public class FinalSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject finalObjectPrefab; // Prefab del objeto final a instanciar
    [SerializeField]
    private Vector3 spawnPosition = new Vector3(0, 0, 0); // Posición donde se spawneará el objeto final
    [SerializeField]
    private float spawnDelay = 30f; // Tiempo en segundos antes de spawnear el objeto

    private void Start()
    {
        print("FinalSpawner.cs: Iniciando spawner del objeto final...");
        // Invocar el método SpawnFinalObject después del tiempo especificado
        Invoke("SpawnFinalObject", spawnDelay);
    }

    private void SpawnFinalObject()
    {
        if (finalObjectPrefab != null)
        {
            Instantiate(finalObjectPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Objeto final spawneado en: " + spawnPosition);
        }
        else
        {
            Debug.LogError("El prefab del objeto final no está asignado.");
        }
    }
}
