using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPelota : MonoBehaviour
{
    public float velocidad = 13f;
    public Transform puntoSpawn;
    public InputActionReference accionLanzar;

    private Rigidbody rb;
    private bool enJuego = false;


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
        if (enJuego == true)
            rb.linearVelocity = rb.linearVelocity.normalized * velocidad;
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
        rb.linearVelocity = Vector3.zero;
        this.gameObject.transform.position = puntoSpawn.position;
    }
}
