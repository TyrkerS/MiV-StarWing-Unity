using UnityEngine;

public class SpawnerHeal : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab; // Prefab del objeto a instanciar
    [SerializeField]
    private float spawnRate = 2f; // Frecuencia de aparición en segundos

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = spawnRate; // Inicializa el temporizador
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObject();
            timer = spawnRate; // Reinicia el temporizador
        }
    }

    private void SpawnObject()
    {
        // Generar posiciones aleatorias dentro de los rangos
        float x = Random.Range(-35f, 35f);
        float y = Random.Range(10f, 20f);
        float z = 140f;

        // Instanciar el objeto en la posición calculada
        Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
    }
}