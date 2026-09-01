using UnityEngine;

public class Bloque : MonoBehaviour
{
    public int puntos = 10;
    public int resistencia = 1;
    private ControladorAudio controladorAudio;
    private ControladorJuego controlador;
    private Renderer render;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlador = GameObject.FindFirstObjectByType<ControladorJuego>();
        controladorAudio = GameObject.FindFirstObjectByType<ControladorAudio>();
        render = this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pelota"))
        {
            resistencia --; 
            controladorAudio.ReproducirEfecto(controladorAudio.sfxRomperBloque);

            if(resistencia <= 0)
            {
                controlador.SumarPuntaje(puntos);
                GameObject.Destroy(this.gameObject);
            }
            else
            {
                MostrarDanio();
            }
            
        }
    }

    void MostrarDanio()
    {
        Color c = render.material.color * 0.55f;
        c.a = 1f;
        render.material.color = c;
    }
}
