using UnityEngine;

public class Vertical : MonoBehaviour
{
    void Start()
    {
        // Permitir rotación automática solo a retrato (vertical)
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;

        // Cambiar la orientación a vertical (portrait)
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
