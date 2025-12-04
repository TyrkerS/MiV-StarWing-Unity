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

    public void InicialitzarBarra(float vida)
    {
        slider.maxValue = vida;
        slider.value = vida;
    }

}
