using UnityEngine;

public class KeyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectKey();
            Destroy(gameObject); // remove key after collecting
        }
    }
}
