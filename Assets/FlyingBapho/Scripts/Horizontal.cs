using UnityEngine;

public class Horizontal : MonoBehaviour
{
    void Start()
    {
        // Permitir rotación automática solo a horizontal derecha
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        // Cambiar la orientación a LandscapeRight para forzar la dirección específica
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }
}
