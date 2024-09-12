using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Delegado y evento para notificar cambios en las necesidades
    public delegate void NecesidadCambiada(Necesidad tipo, float nuevoValor);
    public static event NecesidadCambiada OnNecesidadCambiada;

    private void Awake()
    {
        // Implementar Singleton para asegurar una única instancia del GameManager
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // Si ya existe otra instancia del GameManager, destruir este GameObject
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Asegura que el GameManager persista entre escenas
        }
    }

    // Método para actualizar las necesidades
    public void ActualizarNecesidad(Necesidad tipo, float nuevoValor)
    {
        // Aquí se puede manejar la lógica de actualización de necesidades
        Debug.Log("Necesidad actualizada: " + tipo + " con valor: " + nuevoValor);

        // Invocar el evento para notificar a los suscriptores
        OnNecesidadCambiada?.Invoke(tipo, nuevoValor);
    }
}

// Enum para las diferentes necesidades de la mascota
public enum Necesidad
{
    Hambre,
    Energia,
    Higiene,
    Felicidad
}
