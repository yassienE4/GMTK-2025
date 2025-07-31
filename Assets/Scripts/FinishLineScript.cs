using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLineScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.AllKeysCollected())
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);

        }
        else if (other.CompareTag("Player"))
        {
            //Debug.Log("You need to collect all the keys first!");
        }
    }
}
