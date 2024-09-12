using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioEscena : MonoBehaviour
{
    // Este método se llamará desde los botones en el Inspector
    public void CambiarEscena(string nombreDeEscena)
    {
        Debug.Log("Cambiando a la escena: " + nombreDeEscena);
        SceneManager.LoadScene(nombreDeEscena);
    }
}
