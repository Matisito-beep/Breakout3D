using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPelota : MonoBehaviour
{
    public float velocidad = 13f;
    public float velocidadMaxima = 22f;
    public float aumentoPorBloque = 0.15f;
    public float componenteMinimaY = 0.35f;
    public float mitadPaleta = 1.5f;
    public Transform puntoSpawn;
    public InputActionReference accionLanzar;

    private Rigidbody rb;
    private bool enJuego = false;
    private ControladorAudio controladorAudio;
    private float velocidadInicial;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        accionLanzar.action.Enable();
    }

    void OnDisable()
    {
        accionLanzar.action.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        controladorAudio = GameObject.FindFirstObjectByType<ControladorAudio>();
        velocidadInicial = velocidad;
        Reiniciar();
    }

    // Update is called once per frame
    void Update()
    {
        if (enJuego == false)
        {
            this.gameObject.transform.position = puntoSpawn.position;

            if (accionLanzar.action.WasPressedThisFrame())
                Lanzar();
        }

        
    }

    void FixedUpdate()
    {
        if (enJuego == false)
            return;
        
        Vector3 direccion = rb.linearVelocity.normalized;
        
        if (Mathf.Abs(direccion.y)< componenteMinimaY)
        {
            float signo = 1f;
            if (direccion.y < 0f)
                signo = -1f;

            direccion.y = componenteMinimaY * signo;
            direccion = direccion.normalized;
        }

        rb.linearVelocity = direccion * velocidad;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paleta"))
        {
            RebotarEnPelota(collision.transform.position.x);
            controladorAudio.ReproducirEfecto(controladorAudio.sfxGolpeMuro);
        }
        
        else if (collision.gameObject.CompareTag("Muro"))
        {
            controladorAudio.ReproducirEfecto(controladorAudio.sfxGolpeMuro);
        }
            
    }

    void RebotarEnPelota(float centroPaleta)
    {
        float desvio = this.gameObject.transform.position.x - centroPaleta;
        float factor = Mathf.Clamp(desvio/ mitadPaleta, -1f, 1f);

        Vector3 direccion = new Vector3(factor, 1f, 0f).normalized;
        rb.linearVelocity = direccion * velocidad; 
    }

    public void Acelerar()
    {
        velocidad = Mathf.Min(velocidad + aumentoPorBloque, velocidadMaxima);
    }
    public void Lanzar()
    {
        enJuego = true;
        Vector3 direccion = new Vector3(Random.Range(-0.4f, 0.4f), 1f, 0f);
        rb.linearVelocity = direccion.normalized * velocidad;
    }

    public void Reiniciar()
    {
        enJuego = false;
        velocidad = velocidadInicial; 
        rb.linearVelocity = Vector3.zero;
        this.gameObject.transform.position = puntoSpawn.position;
    }

    
}
