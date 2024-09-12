using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float velocidad;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}
