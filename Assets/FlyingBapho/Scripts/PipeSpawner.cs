using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float tiempoMax = 1; // Tiempo entre generación de obstáculos
    private float tiempoInicial = 0; // Temporizador para la generación
    public GameObject obstaculo; // Prefab del obstáculo (tubería)
    public float altura; // Rango de altura donde se pueden generar los obstáculos

    // Update is called once per frame
    void Update()
    {
        // Si ha pasado suficiente tiempo, genera un nuevo obstáculo
        if (tiempoInicial > tiempoMax)
        {
            SpawnPipe();
            tiempoInicial = 0; // Reinicia el temporizador
        }
        else
        {
            // Incrementa el temporizador
            tiempoInicial += Time.deltaTime;
        }
    }

    void SpawnPipe()
    {
        // Instancia el nuevo obstáculo (tubería)
        GameObject obstaculoNuevo = Instantiate(obstaculo);

        // Ajusta la posición del nuevo obstáculo dentro del rango permitido
        obstaculoNuevo.transform.position = transform.position + new Vector3(0, Random.Range(-altura, altura), 0);

        // Verifica que los colisionadores estén activados en el nuevo obstáculo
        BoxCollider2D[] colliders = obstaculoNuevo.GetComponentsInChildren<BoxCollider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = true; // Asegúrate de que los colliders estén activados
        }

        // Destruye el obstáculo después de un tiempo para no sobrecargar la memoria
        Destroy(obstaculoNuevo, 10f);
    }

    // Método para detectar colisiones del personaje con los tubos
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión con: " + collision.gameObject.name); // Log para verificar con qué objeto colisiona

        // Si el personaje colisiona con un tubo
        if (collision.gameObject.tag == "Tubo")
        {
            Debug.Log("Colisión detectada con un tubo");

            // Aquí puedes detener el movimiento del personaje
            // Rigidbody2D rb = GetComponent<Rigidbody2D>();
            // rb.velocity = Vector2.zero;
        }
    }
}
