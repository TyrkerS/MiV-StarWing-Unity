using UnityEngine;

public class SpawnerED : MonoBehaviour
{
    [SerializeField]
    float z = 140;
    [SerializeField]
    private float spawnRate = 1f; // Frecuencia de aparición
    [SerializeField]
    private GameObject prefab; // Prefab del objeto a instanciar

    private float x = 0f; // Posición en el eje X entre -40 y 40
    [SerializeField]
    private float y = -10f; // Base en Y ajustada según el escalado

    private float minScaleX = 5f; // Escala mínima en el eje X
    private float maxScaleX = 25f; // Escala máxima en el eje X
    private float minScaleY = 10f; // Escala mínima en el eje Y
    private float maxScaleY = 45f; // Escala máxima en el eje Y
    private float minScaleZ = 5f; // Escala mínima en el eje Z
    private float maxScaleZ = 25f; // Escala máxima en el eje Z

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

        // Generar un escalado aleatorio
        float scaleX = Random.Range(minScaleX, maxScaleX);
        float scaleY = Random.Range(minScaleY, maxScaleY);
        float scaleZ = Random.Range(minScaleZ, maxScaleZ);

        // Ajustar Y para que la base del edificio quede en -5
        y = -10 + (scaleY / 2f);

        // Crear el edificio
        GameObject building = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);

        // Aplicar el escalado al edificio
        building.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
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
