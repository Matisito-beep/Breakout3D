using UnityEngine;

public class ControladorAudio : MonoBehaviour
{
    public AudioSource fuenteMusica;
    public AudioSource fuenteEfectos;

    public AudioClip musicaFondo;
    public AudioClip sfxGolpePaleta;
    public AudioClip sfxGolpeMuro;
    public AudioClip sfxRomperBloque;
    public AudioClip sfxPerderVida;
    public AudioClip sfxVictoria;
    public AudioClip sfxClickUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuenteMusica.clip = musicaFondo;
        fuenteMusica.loop = true;
        fuenteMusica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReproducirEfecto(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        fuenteEfectos.PlayOneShot(clip);
    } 
}
