using UnityEngine;
using UnityEngine.UIElements;

public class GameHudScript : MonoBehaviour
{
    [SerializeField] private TileSwitcherScript tileSwitcher; // Reference to your TileSwitcherScript
    [SerializeField] private GameManager gameManager;
    private Label keysLabel;
    private Label timerLabel;

    void OnEnable()
    {
        // Get root UI element
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Get UI elements by name
        keysLabel = root.Q<Label>("keys-label");
        timerLabel = root.Q<Label>("timer-label");

        // Fallback: find TileSwitcher in scene if not assigned
        if (tileSwitcher == null)
            tileSwitcher = FindObjectOfType<TileSwitcherScript>();
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();

        // Initial display
        UpdateKeysUI();
        UpdateTimerUI(tileSwitcher?.TimerRemaining ?? 0f);
    }

    void Update()
    {
        // Update countdown timer every frame
        if (tileSwitcher != null)
        {
            UpdateTimerUI(tileSwitcher.TimerRemaining);
        }
    }

    public void UpdateKeysUI()
    {
        int remaining = gameManager.getKeysLeft();
        keysLabel.text = $"{remaining}";
    }

    private void UpdateTimerUI(float time)
    {
        int seconds = Mathf.CeilToInt(time);
        timerLabel.text = $"00:{seconds:00}";
    }
}