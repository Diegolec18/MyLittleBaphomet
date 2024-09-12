using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float velocity = 1;
    private Rigidbody2D rb;
    public ControladorEscena controladorEscena;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.linearVelocity = Vector2.up * velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        controladorEscena.Perdiste();
    }
}
