using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public UIDocument uiDocument;

    void Start()
    {
        var root = uiDocument.rootVisualElement;

        // BOTÓN JUGAR
        var botonJugar = root.Q<Button>("Jugar");
        if (botonJugar != null)
        {
            botonJugar.clicked += () =>
            {
                SceneManager.LoadScene("Mario");
            };
        }
        else
        {
            Debug.LogWarning("No se encontró el botón 'Jugar'");
        }

        // BOTÓN SALIR
        var botonSalir = root.Q<Button>("BotonSalir");
        if (botonSalir != null)
        {
            botonSalir.clicked += () =>
            {
                Application.Quit();
                Debug.Log("El juego se cerraría aquí (solo en build)");
            };
        }
        else
        {
            Debug.LogWarning("No se encontró el botón 'BotonSalir'");
        }
    }
}


