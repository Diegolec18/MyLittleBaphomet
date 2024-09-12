using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Slider hambreSlider;
    public Slider energiaSlider;
    public Slider higieneSlider;
    public Slider felicidadSlider;

    private void OnEnable()
    {
        // Suscribirse al evento de cambio de necesidades
        GameManager.OnNecesidadCambiada += ActualizarSliders;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento para evitar errores
        GameManager.OnNecesidadCambiada -= ActualizarSliders;
    }

    // Actualizar los sliders cuando cambie alguna necesidad
    void ActualizarSliders(Necesidad tipo, float nuevoValor)
    {
        switch (tipo)
        {
            case Necesidad.Hambre:
                hambreSlider.value = nuevoValor / 100; // Normaliza entre 0 y 1
                break;
            case Necesidad.Energia:
                energiaSlider.value = nuevoValor / 100;
                break;
            case Necesidad.Higiene:
                higieneSlider.value = nuevoValor / 100;
                break;
            case Necesidad.Felicidad:
                felicidadSlider.value = nuevoValor / 100;
                break;
        }
    }
}
