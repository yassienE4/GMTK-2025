using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    private Button startButton;
    private Button quitButton;
    [SerializeField] private string startSceneName = "GameScene";

    void OnEnable()
    {
        // Get the root of the UI
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Query the buttons by name
        startButton = root.Q<Button>("start-button");
        quitButton = root.Q<Button>("quit-button");

        // Register callbacks
        startButton.clicked += OnStartClicked;
        quitButton.clicked += OnQuitClicked;
    }

    private void OnStartClicked()
    {
        // Replace with your actual scene name or index
        SceneManager.LoadScene(startSceneName);
    }

    private void OnQuitClicked()
    {
        // Works only in build, not in editor
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}