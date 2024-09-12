using UnityEngine;

public class DormirBoton : MonoBehaviour
{
    public NecesidadesMascota mascota;

    public void OnClickDormir()
    {
        mascota.DormirMascota();  // Llamar el método para dormir
    }
}
