using UnityEngine;
using UnityEngine.SceneManagement; // Da acceso a SceneManager

public class MenuInicio : MonoBehaviour
{
    public void IniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); // Escena del nivel

    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // Escena del Menu
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo....");
        Application.Quit();
    }

}
