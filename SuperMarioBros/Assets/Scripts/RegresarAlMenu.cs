using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarAlMenu : MonoBehaviour
{
    // Este método se llama cuando el jugador hace clic en el botón
    void OnMouseDown()
    {
        // Cambia a la escena del menú
        SceneManager.LoadScene("Menu");
    }
}
