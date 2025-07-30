using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalKeys;
    private int keysCollected;


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        keysCollected = 0;
    }

    public int getKeysLeft()
    {
        return totalKeys - keysCollected;
    }

    public void CollectKey()
    {
        keysCollected++;
        //Debug.Log($"Keys: {keysCollected}/{totalKeys}");
    }

    public bool AllKeysCollected()
    {
        return keysCollected >= totalKeys;
    }
}