using UnityEngine;
using UnityEngine.SceneManagement; // Da acceso a SceneManager

public class MenuInicio : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene(1); // Escena del nivel

    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene(0); // Escena del Menu
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo....");
        Application.Quit();
    }

}
