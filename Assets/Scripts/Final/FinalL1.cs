using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalL1 : MonoBehaviour
{
    [SerializeField]
    private GameObject hudFinalNivel; // HUD para el final del nivel
    [SerializeField]
    private GameObject hudFinalJoc;  // HUD para el final del juego

    private GameObject canvasInstance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Nivel terminado");
            // Cambiar la posición del jugador
            other.transform.position = new Vector3(700, 101, -233);
            PlayerPrefs.SetInt("LastLevelIndex", SceneManager.GetActiveScene().buildIndex);

            if (SceneManager.GetActiveScene().buildIndex < 4)
            {
                SceneManager.LoadScene(6);
            }
            else
            {
                SceneManager.LoadScene(5);
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
