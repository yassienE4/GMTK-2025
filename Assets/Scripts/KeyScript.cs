using UnityEngine;

public class KeyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectKey();
            GameHudScript hud = FindObjectOfType<GameHudScript>();
            if (hud != null)
            {
                hud.UpdateKeysUI();
            }
            Destroy(gameObject); // remove key after collecting
        }
    }
}
