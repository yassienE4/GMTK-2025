using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.AllKeysCollected())
        {
            Debug.Log("Level Complete!");
        }
        else if (other.CompareTag("Player"))
        {
            //Debug.Log("You need to collect all the keys first!");
        }
    }
}
