using UnityEngine;

public class Vertical : MonoBehaviour
{
    void Start()
    {
        // Permitir rotaci�n autom�tica solo a retrato (vertical)
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;

        // Cambiar la orientaci�n a vertical (portrait)
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
