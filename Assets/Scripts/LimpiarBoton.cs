using UnityEngine;

public class LimpiarBoton : MonoBehaviour
{
    public NecesidadesMascota mascota;

    public void OnClickLimpiar()
    {
        mascota.LimpiarMascota();  // Llamar el método para limpiar
    }
}
