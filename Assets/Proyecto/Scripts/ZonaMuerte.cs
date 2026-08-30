using UnityEngine;

public class ZonaMuerte : MonoBehaviour
{
    private ControladorJuego controlador;
    private ControladorAudio controladorAudio;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pelota"))
        {
            controladorAudio.ReproducirEfecto(controladorAudio.sfxPerderVida);
            controlador.PerderVida();
        }
    }
}
