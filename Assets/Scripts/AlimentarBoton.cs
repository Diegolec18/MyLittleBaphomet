using UnityEngine;

public class AlimentarBoton : MonoBehaviour
{
    public NecesidadesMascota mascota;

    public void OnClickAlimentar()
    {
        mascota.AlimentarMascota();  // Llamar el método para alimentar
    }
}
