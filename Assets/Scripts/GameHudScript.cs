using UnityEngine;
using UnityEngine.UIElements;

public class GameHudScript : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    private Label keysLabel;


    void OnEnable()
    {
        // Get root UI element
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Get UI elements by name
        keysLabel = root.Q<Label>("keys-label");


        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();

        // Initial display
        UpdateKeysUI();
        
    }
    

    public void UpdateKeysUI()
    {
        int remaining = gameManager.getKeysLeft();
        keysLabel.text = $"{remaining}";
    }

    
}