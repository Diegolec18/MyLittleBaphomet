using UnityEngine;
using System.Collections;

public class NecesidadesMascota : MonoBehaviour
{
    public float nivelHambre = 100f;
    public float nivelEnergia = 100f;
    public float nivelHigiene = 100f;
    public float nivelFelicidad = 100f;

    public float decrementoHambrePorSegundo = 1f;
    public float decrementoEnergiaPorSegundo = 0.5f;
    public float decrementoHigienePorSegundo = 0.3f;
    public float decrementoFelicidadPorSegundo = 0.2f;

    public float incrementoHambrePorComida = 20f;
    public float incrementoEnergiaPorDormir = 30f;
    public float incrementoHigienePorBanarse = 40f;
    public float incrementoFelicidadPorAcariciar = 10f;

    private bool acariciando = false;
    public bool durmiendo = false;

    void Update()
    {
        ActualizarNecesidades(); // Decrementar las necesidades cada frame
        DetectarAcariciar(); // Detectar si el jugador está acariciando a la mascota
    }

    // Método para actualizar las necesidades, haciendo que bajen con el tiempo
    void ActualizarNecesidades()
    {
        nivelHambre -= decrementoHambrePorSegundo * Time.deltaTime;
        nivelEnergia -= decrementoEnergiaPorSegundo * Time.deltaTime;
        nivelHigiene -= decrementoHigienePorSegundo * Time.deltaTime;
        nivelFelicidad -= decrementoFelicidadPorSegundo * Time.deltaTime;

        // Asegurarse de que los valores no bajen de 0
        nivelHambre = Mathf.Clamp(nivelHambre, 0, 100);
        nivelEnergia = Mathf.Clamp(nivelEnergia, 0, 100);
        nivelHigiene = Mathf.Clamp(nivelHigiene, 0, 100);
        nivelFelicidad = Mathf.Clamp(nivelFelicidad, 0, 100);

        // Notificar los cambios al GameManager
        GameManager.instance.ActualizarNecesidad(Necesidad.Hambre, nivelHambre);
        GameManager.instance.ActualizarNecesidad(Necesidad.Energia, nivelEnergia);
        GameManager.instance.ActualizarNecesidad(Necesidad.Higiene, nivelHigiene);
        GameManager.instance.ActualizarNecesidad(Necesidad.Felicidad, nivelFelicidad);
    }

    // Método para alimentar a la mascota
    public void AlimentarMascota()
    {
        nivelHambre += incrementoHambrePorComida;
        nivelHambre = Mathf.Clamp(nivelHambre, 0, 100);

        GameManager.instance.ActualizarNecesidad(Necesidad.Hambre, nivelHambre);

        Debug.Log("¡La mascota ha sido alimentada!");
    }

    // Método para hacer que la mascota duerma
    public void DormirMascota()
    {
        durmiendo = true;
        StartCoroutine(IncrementarEnergiaDuranteSueno());
    }

    IEnumerator IncrementarEnergiaDuranteSueno()
    {
        while (durmiendo && nivelEnergia < 100)
        {
            nivelEnergia += incrementoEnergiaPorDormir * Time.deltaTime;
            nivelEnergia = Mathf.Clamp(nivelEnergia, 0, 100);

            GameManager.instance.ActualizarNecesidad(Necesidad.Energia, nivelEnergia);

            yield return null;
        }

        durmiendo = false;
        Debug.Log("¡La mascota ha terminado de dormir!");
    }

    // Método para limpiar a la mascota
    public void LimpiarMascota()
    {
        nivelHigiene += incrementoHigienePorBanarse;
        nivelHigiene = Mathf.Clamp(nivelHigiene, 0, 100);

        GameManager.instance.ActualizarNecesidad(Necesidad.Higiene, nivelHigiene);

        Debug.Log("¡La mascota ha sido limpiada!");
    }

    // Detectar cuando el jugador acaricia la mascota
    void DetectarAcariciar()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            Vector2 toquePos = Camera.main.ScreenToWorldPoint(toque.position);

            Collider2D colision = Physics2D.OverlapPoint(toquePos);

            if (colision != null && colision.gameObject == this.gameObject)
            {
                if (toque.phase == TouchPhase.Moved || toque.phase == TouchPhase.Stationary)
                {
                    acariciando = true;
                    IncrementarFelicidad();
                }
            }
        }
    }

    // Incrementar felicidad al acariciar
    void IncrementarFelicidad()
    {
        if (acariciando)
        {
            nivelFelicidad += incrementoFelicidadPorAcariciar * Time.deltaTime;
            nivelFelicidad = Mathf.Clamp(nivelFelicidad, 0, 100);

            GameManager.instance.ActualizarNecesidad(Necesidad.Felicidad, nivelFelicidad);
        }
    }
}