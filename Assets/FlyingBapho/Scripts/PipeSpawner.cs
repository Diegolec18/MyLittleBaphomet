using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float tiempoMax = 1; // Tiempo entre generaci�n de obst�culos
    private float tiempoInicial = 0; // Temporizador para la generaci�n
    public GameObject obstaculo; // Prefab del obst�culo (tuber�a)
    public float altura; // Rango de altura donde se pueden generar los obst�culos

    // Update is called once per frame
    void Update()
    {
        // Si ha pasado suficiente tiempo, genera un nuevo obst�culo
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
        // Instancia el nuevo obst�culo (tuber�a)
        GameObject obstaculoNuevo = Instantiate(obstaculo);

        // Ajusta la posici�n del nuevo obst�culo dentro del rango permitido
        obstaculoNuevo.transform.position = transform.position + new Vector3(0, Random.Range(-altura, altura), 0);

        // Verifica que los colisionadores est�n activados en el nuevo obst�culo
        BoxCollider2D[] colliders = obstaculoNuevo.GetComponentsInChildren<BoxCollider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = true; // Aseg�rate de que los colliders est�n activados
        }

        // Destruye el obst�culo despu�s de un tiempo para no sobrecargar la memoria
        Destroy(obstaculoNuevo, 10f);
    }

    // M�todo para detectar colisiones del personaje con los tubos
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisi�n con: " + collision.gameObject.name); // Log para verificar con qu� objeto colisiona

        // Si el personaje colisiona con un tubo
        if (collision.gameObject.tag == "Tubo")
        {
            Debug.Log("Colisi�n detectada con un tubo");

            // Aqu� puedes detener el movimiento del personaje
            // Rigidbody2D rb = GetComponent<Rigidbody2D>();
            // rb.velocity = Vector2.zero;
        }
    }
}
