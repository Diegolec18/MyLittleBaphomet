using TMPro;
using UnityEngine;

public class Contador : MonoBehaviour
{
    public static int puntaje = 0;

    // Start is called before the first frame update
    void Start()
    {
        puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = puntaje.ToString();
    }
}
