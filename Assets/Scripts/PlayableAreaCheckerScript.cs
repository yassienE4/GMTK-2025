using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayableAreaCheckerScript : MonoBehaviour
{
    [SerializeField] private Tilemap[] backgroundTilemaps;
    [SerializeField] private Transform ball;
    private float outOfBoundsTime = 0f;
    public float timeToReset = 0.3f;
    public int index = 0;

    void Update()
    {
        Vector3Int tilePos = backgroundTilemaps[index].WorldToCell(ball.position);

        if (!backgroundTilemaps[index].HasTile(tilePos))
        {
            outOfBoundsTime += Time.deltaTime;
            if (outOfBoundsTime >= timeToReset)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
        else
        {
            outOfBoundsTime = 0f;
        }
    }
    
    void OnEnable()
    {
        TileSwitcherScript.OnCountdownFinishedEvent += UpdateIndex;
    }
    void OnDisable()
    {
        TileSwitcherScript.OnCountdownFinishedEvent -= UpdateIndex;
    }
    void UpdateIndex()
    {
        index = (index + 1) % backgroundTilemaps.Length;
    }
}
