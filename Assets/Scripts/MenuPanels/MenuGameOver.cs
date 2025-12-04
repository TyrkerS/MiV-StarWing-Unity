using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public Button botoRespawn; 
    public Button botoMenuFi; 
    public GameObject menuGameOver;
    public GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        menuGameOver = canvas.transform.Find("GameOver")?.gameObject;

        botoRespawn = menuGameOver.transform.Find("BotoRespawn").GetComponent<Button>();
        botoMenuFi = menuGameOver.transform.Find("BotoTornarMenu").GetComponent<Button>();

        botoRespawn.onClick.AddListener(() => OnClick("Respawn"));
        botoMenuFi.onClick.AddListener(() => OnClick("MenuFi"));
    }

    void OnClick(string accio)
    {
        switch (accio)
        {
            case "Respawn":
                SceneManager.LoadScene(2);
                break;
            
            case "MenuFi":
                SceneManager.LoadScene(0);
                break;
            
            default:
                Debug.LogError("Acció desconeguda");
                break;
        }
    }
}
