using UnityEngine;
using TMPro;

public class ControladorJuego : MonoBehaviour
{
    public int vidasIniciales = 3;
    public TMP_Text textoPuntaje;
    public TMP_Text textoVidas;
    public GameObject panelGameOver;
    public GameObject panelVictoria;
    public Transform contenedorBloques;
    public ControladorPelota pelota;

    private int puntaje = 0;
    private int vidas;
    private ControladorAudio controladorAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntaje = 0;
        vidas = vidasIniciales;
        ActualizarTextos();
        controladorAudio = GameObject.FindFirstObjectByType<ControladorAudio>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumarPuntaje(int cantidad)
    {
        puntaje += cantidad;
        pelota.Acelerar();
        ActualizarTextos();
        RevisarVictoria();
    }

    public void PerderVida()
    {
        vidas--;
        ActualizarTextos();

        if (vidas <= 0)
            panelGameOver.SetActive(true);
        else
            pelota.Reiniciar();

    }

    void RevisarVictoria()
    {
        int bloquesRestantes = contenedorBloques.GetComponentsInChildren<Bloque>().Length;
        if (bloquesRestantes <=1)
            panelVictoria.SetActive(true);
            controladorAudio.ReproducirEfecto(controladorAudio.sfxVictoria);
            

    }

    void ActualizarTextos()
    {
        textoPuntaje.text= "PUNTAJE: " + puntaje.ToString("0000");
        textoVidas.text = "VIDAS: " + vidas.ToString();
    }
}
