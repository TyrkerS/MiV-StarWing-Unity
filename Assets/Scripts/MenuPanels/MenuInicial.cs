using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInici : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(2);
    }

    public void Sortir()
    {
        Debug.Log("Sortint del joc...");
        Application.Quit();
    }
}
