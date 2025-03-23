using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("Jugar").clicked += () => SceneManager.LoadScene("SampleScene");
        root.Q<Button>("Ayuda").clicked += () => SceneManager.LoadScene("Ayuda");
        root.Q<Button>("Creditos").clicked += () => SceneManager.LoadScene("Creditos");
        root.Q<Button>("Salir").clicked += Application.Quit;
    }
}
