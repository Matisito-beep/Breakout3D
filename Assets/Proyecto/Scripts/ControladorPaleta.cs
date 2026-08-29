using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPaleta : MonoBehaviour
{
    public float velocidad = 15f;
    public float limiteX= 8.5f;
    public InputActionReference accionMover;

    // 
    void OnEnable()
    {
        accionMover.action.Enable();
    }

    void OnDisable()
    {
        accionMover.action.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direccion = accionMover.action.ReadValue<float>();

        Vector3 posicion = this.gameObject.transform.position;

        posicion.x += direccion * velocidad * Time.deltaTime;
        posicion.x = Mathf.Clamp(posicion.x, -limiteX, limiteX);
         
        this.gameObject.transform.position = posicion; 

        
    }
}
