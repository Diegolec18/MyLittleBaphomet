using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Delegado y evento para notificar cambios en las necesidades
    public delegate void NecesidadCambiada(Necesidad tipo, float nuevoValor);
    public static event NecesidadCambiada OnNecesidadCambiada;

    private void Awake()
    {
        // Implementar Singleton para asegurar una �nica instancia del GameManager
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

    // M�todo para actualizar las necesidades
    public void ActualizarNecesidad(Necesidad tipo, float nuevoValor)
    {
        // Aqu� se puede manejar la l�gica de actualizaci�n de necesidades
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
