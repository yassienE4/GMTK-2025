using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this object between scenes
            GetComponent<AudioSource>().Play();  // Start playing the music
        }
        else
        {
            Destroy(gameObject);  // Prevent duplicate music players
        }
    }
}
