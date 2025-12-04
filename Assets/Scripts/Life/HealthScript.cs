using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private float maxHealth; // Vida máxima del objeto

    private float currentHealth; // Vida actual del objeto

    [SerializeField] private Barra BarraVida;

    public GameObject HUDBarra;

    public GameObject canvas;

    private AudioSource audioSource;

    [SerializeField] private AudioClip collisionSound; // Sonido de colisión

    private AudioSource audioSource2;

    [SerializeField] private AudioClip lifeSound; // Sonido de colisión

    private AudioSource audioSource3;

    [SerializeField] private AudioClip deathSound; // Sonido de colisión


    void Start()
    {
        // Inicializar la vida al máximo al comienzo
        currentHealth = maxHealth;
        if (gameObject.CompareTag("Player"))
        {
            canvas = GameObject.Find("PausaVida");
            HUDBarra = canvas.transform.Find("Panel")?.gameObject;
            BarraVida = HUDBarra.transform.Find("Barra").GetComponent<Barra>();
            BarraVida.InicialitzarBarra(maxHealth);

            // Configurar el AudioSource
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip = collisionSound;

            audioSource2 = gameObject.AddComponent<AudioSource>();
            audioSource2.playOnAwake = false;
            audioSource2.clip = lifeSound;

            audioSource3 = gameObject.AddComponent<AudioSource>();
            audioSource3.playOnAwake = false;
            audioSource3.clip = deathSound;
        }
    }

    // Método para recibir daño
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reducir la vida actual
        print($"El objeto ha recibido {damage} de daño. Vida restante: {currentHealth}");

        if (gameObject.CompareTag("Player")) {
            BarraVida.CanviarVidaActual(currentHealth);
            audioSource.Play(); // Reproducir el sonido
        }
        // Si la vida llega a 0, destruir el objeto
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método para curar al objeto
    public void Heal(float amount)
    {
        currentHealth += amount; // Aumentar la vida actual
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Asegurarse de que no supere la vida máxima
        print($"El objeto ha sido curado. Vida actual: {currentHealth}");

        if (gameObject.CompareTag("Player")) {
            audioSource2.Play(); // Reproducir el sonido
            BarraVida.CanviarVidaActual(currentHealth);
        }

    }

    // Método para destruir el objeto
    private void Die()
    {
        Destroy(gameObject); // Destruir el objeto de la escena
        //audioSource3.Play(); // Reproducir el sonido
        
        if (gameObject.CompareTag("Player")) {
            Debug.Log("El jugador ha muerto.");
            SceneManager.LoadScene(1);
        }
    }
}
