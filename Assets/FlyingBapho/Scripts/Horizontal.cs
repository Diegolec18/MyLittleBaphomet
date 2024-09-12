using UnityEngine;

public class Horizontal : MonoBehaviour
{
    void Start()
    {
        // Permitir rotaci�n autom�tica solo a horizontal derecha
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        // Cambiar la orientaci�n a LandscapeRight para forzar la direcci�n espec�fica
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }
}
