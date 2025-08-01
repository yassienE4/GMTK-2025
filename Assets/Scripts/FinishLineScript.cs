using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLineScript : MonoBehaviour
{
    public AudioClip finishSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.AllKeysCollected())
        {
            PlayFinishSoundAcrossScenes();
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);

        }
        else if (other.CompareTag("Player"))
        {
            //Debug.Log("You need to collect all the keys first!");
        }
    }
    
    void PlayFinishSoundAcrossScenes()
    {
        GameObject tempAudio = new GameObject("TempAudio");
        AudioSource tempSource = tempAudio.AddComponent<AudioSource>();
        tempSource.clip = finishSound;
        tempSource.Play();
        DontDestroyOnLoad(tempAudio);
        Destroy(tempAudio, finishSound.length); // clean it up after sound finishes
    }

}
