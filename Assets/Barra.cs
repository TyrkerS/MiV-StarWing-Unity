using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{

    private Slider slider;

    private Animator anim;

    private void Start()
    {
        slider = GetComponent<Slider>();
        anim = GetComponent<Animator>();
    }

    public void CanviarVidaMaxima(float vida)
    {
        slider.maxValue = vida;
    }

    public void CanviarVidaActual(float vida)
    {
        slider.value = vida;
        anim.SetTrigger("cop");
    }

    public void ActualitzarPowerUp(float valor)
    {
        slider.value = valor;
    }

    public void InicialitzarBarra(float vida)
    {
        if(slider == null)
        {
            Debug.Log("Slider no inicializado. Inicializando...");
            slider = GetComponent<Slider>();
        }
        slider.maxValue = vida;
        slider.value = vida;
    }

    public void InicialitzarBarraPUp(float valorMax)
    {
        if(slider == null)
        {
            Debug.Log("Slider no inicializado. Inicializando...");
            slider = GetComponent<Slider>();
        }
        slider.maxValue = valorMax;
        slider.value = 0;
    }

}
