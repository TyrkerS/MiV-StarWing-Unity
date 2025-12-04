using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDJoc : MonoBehaviour
{

    public void Pausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("MenuPausa");
        }
    }

}
