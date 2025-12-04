using UnityEngine;

public class SpawnerEspai : MonoBehaviour
{
    [SerializeField]
    float z = 140;
    [SerializeField]
    private float spawnRate = 1f; // Frecuencia de aparición
    [SerializeField]
    private GameObject prefab; // Prefab del objeto a instanciar

    private float x = 0f; // Posición en el eje X entre -40 y 40
    private float y = 0f; // Posición aleatoria en Y entre -10 y 50

    [SerializeField]
    private float minScale = 3f; // Escala mínima uniforme
    [SerializeField]
    private float maxScale = 6f; // Escala máxima uniforme

    private float timer = 0f;

    private float spawnRateOriginal; // Frecuencia de aparición original

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = spawnRate; // Inicializa el temporizador
        spawnRateOriginal = spawnRate; // Guarda la frecuencia de aparición original
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnBuilding();
            timer = spawnRate; // Reinicia el temporizador
        }
    }

    private void SpawnBuilding()
    {
        // Calcular una posición aleatoria en X entre -40 y 40
        x = Random.Range(-40f, 40f);

        // Calcular una posición aleatoria en Y entre -10 y 50
        y = Random.Range(-10f, 50f);

        // Calcular un escalado uniforme aleatorio entre los valores configurados
        float scale = Random.Range(minScale, maxScale);

        // Crear el edificio con escalado uniforme
        GameObject building = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
        building.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Método para modificar la frecuencia de aparición
    public void ModifySpawnRate(float newSpawnRate)
    {
        spawnRate = newSpawnRate;
    }

    // Método para obtener la frecuencia de aparición original
    public float GetOriginalSpawnRate()
    {
        return spawnRateOriginal;
    }
}