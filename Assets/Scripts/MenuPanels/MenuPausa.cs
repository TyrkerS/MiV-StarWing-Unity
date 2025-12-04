using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public GameObject pausa;
    public Button botoTornar;
    public Button botoReiniciar;
    public Button botoTornarMenu;
    private bool pausat = false;
    public GameObject canvas;

    [SerializeField]
    public AudioSource audioSource;
    
    void Awake()
    {

        //DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        canvas = GameObject.Find("PausaVida");
        pausa = canvas.transform.Find("Pausa")?.gameObject;
        botoTornar = pausa.transform.Find("BotoTornarJoc").GetComponent<Button>();
        botoReiniciar = pausa.transform.Find("BotoReiniciar").GetComponent<Button>();
        botoTornarMenu = pausa.transform.Find("BotoTornarMenu").GetComponent<Button>();

        botoTornar.onClick.AddListener(() => OnClick("Tornar"));
        botoReiniciar.onClick.AddListener(() => OnClick("Reiniciar"));
        botoTornarMenu.onClick.AddListener(() => OnClick("MenuPrincipal"));

        if (canvas == null)
            Debug.LogError("No s'ha trobat el canvas");

        if (pausa == null)
            Debug.LogError("No s'ha trobat el panell de pausa");

        if (botoTornar == null || botoReiniciar == null || botoTornarMenu == null)
            Debug.LogError("No s'ha trobat algun botó");
    }

    void OnClick(string accio)
    {
        switch (accio)
        {
            case "Tornar":
                Continuar();
                break;
                
            case "Reiniciar":
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            
            case "MenuPrincipal":
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
                break;
            
            default:
                Debug.LogError("Acció desconeguda");
                break;
        }
    }

    void Update()
    {
        // Detectar tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausat)
                Continuar();
            else
                Pausar();
        }
    }

    public void Pausar() {
        Time.timeScale = 0;
        pausa.SetActive(true);
        pausat = true;
        audioSource.Pause();

        
    }

    public void Continuar()
    {
        Time.timeScale = 1;
        pausa.SetActive(false);
        pausat = false;
        audioSource.Play();

    }
}
