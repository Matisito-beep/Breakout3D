using UnityEngine;

public class ZonaMuerte : MonoBehaviour
{
    private ControladorJuego controlador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlador = GameObject.FindFirstObjectByType<ControladorJuego>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pelota"))
        {
            controlador.PerderVida();
        }
    }
}
