using UnityEngine;

public class ScriptMovPoweUp : MonoBehaviour
{
    [SerializeField]
    private float tiemToActive = 10.0f; // Tiempo necesario para cargar el Power-Up
    [SerializeField]
    private float timeActive = 3.0f; // Tiempo que el Power-Up está activo

    private bool isPowerUpReady = false; // Indica si el Power-Up está listo para activarse
    private bool isPowerUpActive = false; // Indica si el Power-Up está activo

    private float powerUpTimer = 0.0f; // Temporizador para cargar el Power-Up
    private float activeTimer = 0.0f; // Temporizador para la duración del Power-Up
    [SerializeField] private Barra BarraPUp;

    public GameObject HUDBarra;

    public GameObject canvas;

    private AudioSource audioSource;

    [SerializeField] private AudioClip tenSecSound;

    private AudioSource audioSource2;

    [SerializeField] private AudioClip hornSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GameObject.Find("PausaVida");
        HUDBarra = canvas.transform.Find("Panel")?.gameObject;
        BarraPUp = HUDBarra.transform.Find("BarraPUp").GetComponent<Barra>();
        BarraPUp.InicialitzarBarraPUp(10);

        print("Power-Up inicializado.");
        powerUpTimer = tiemToActive; // Inicializa el temporizador del Power-Up

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = tenSecSound;

        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.playOnAwake = false;
        audioSource2.clip = hornSound;
    }

    // Update is called once per frame
    void Update()
    {
        HandlePowerUpActivation();
        HandlePowerUpEffect();
    }

    private void HandlePowerUpActivation()
    {
        float tempsBarra = 0;
        if (!isPowerUpReady)
        {
            powerUpTimer -= Time.deltaTime;
            tempsBarra += tiemToActive - powerUpTimer;
            BarraPUp.ActualitzarPowerUp(tempsBarra);
            if (powerUpTimer <= 0f)
            {
                audioSource2.Play();
                isPowerUpReady = true;
                Debug.Log("Power-Up listo para activarse.");
            }
        }

        if (isPowerUpReady && Input.GetKeyDown(KeyCode.C))
        {
            isPowerUpActive = true;
            isPowerUpReady = false;
            audioSource.Play();
            activeTimer = timeActive;
            powerUpTimer = tiemToActive;
            Debug.Log("Power-Up activado.");

            // Reducir la velocidad de los edificios y el ritmo de spawn a la mitad
            ModifyBuildingSpeed(0.5f);
            ModifySpawnerRate(3f); 
        }
    }

    private void HandlePowerUpEffect()
    {
        if (isPowerUpActive)
        {
            activeTimer -= Time.deltaTime;
            BarraPUp.ActualitzarPowerUp(activeTimer*2);
            if (activeTimer <= 0f)
            {
                isPowerUpActive = false;
                Debug.Log("Power-Up desactivado.");

                // Restaurar la velocidad original de los edificios y el ritmo de spawn
                ModifyBuildingSpeed(1.0f); // Restaurar al valor original
                ModifySpawnerRate(1.0f); // Restaurar al valor original

                // Reiniciar el tiempo de carga del Power-Up
                powerUpTimer = tiemToActive;
            }
        }
    }

    private void ModifyBuildingSpeed(float speedMultiplier)
    {
        // Encuentra todos los edificios en la escena y ajusta su velocidad
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("edifice");
        foreach (GameObject building in buildings)
        {
            ScriptMovZ buildingMovement = building.GetComponent<ScriptMovZ>();
            if (buildingMovement != null)
            {
                buildingMovement.ModifySpeed(buildingMovement.GetOriginalSpeed() * speedMultiplier);
            }
        }
    }

    private void ModifySpawnerRate(float rateMultiplier)
    {
        // Encuentra todos los SpawnerED en la escena y ajusta su ritmo de spawn
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("SpawnerED");
        foreach (GameObject spawner in spawners)
        {
            SpawnerED spawnerScript = spawner.GetComponent<SpawnerED>();
            if (spawnerScript != null)
            {
                spawnerScript.ModifySpawnRate(spawnerScript.GetOriginalSpawnRate() * rateMultiplier);
            }
        }
    }
}
