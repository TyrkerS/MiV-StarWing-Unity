using UnityEngine;
using UnityEngine.Audio;

public class MenuOpcions : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void Volum(float volum)
    {
        audioMixer.SetFloat("NivellVolum", volum);
    }
}
