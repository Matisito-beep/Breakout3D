using UnityEngine;

public class Bloque : MonoBehaviour
{
    public int puntos = 10;
    private ControladorAudio controladorAudio;

    private ControladorJuego controlador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlador = GameObject.FindFirstObjectByType<ControladorJuego>();
        controladorAudio = GameObject.FindFirstObjectByType<ControladorAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pelota"))
        {
            controlador.SumarPuntaje(puntos);
            controladorAudio.ReproducirEfecto(controladorAudio.sfxRomperBloque);
            GameObject.Destroy(this.gameObject);
        }
    }
}
