using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayableAreaCheckerScript : MonoBehaviour
{
    [SerializeField] private Tilemap[] backgroundTilemaps;
    [SerializeField] private Transform ball;
    [SerializeField] private GameObject uiDeathScreen;
    private float outOfBoundsTime = 0f;
    public float timeToReset = 0.3f;
    public int index = 0;
    private bool dead = false;

    void Update()
    {
        Vector3Int tilePos = backgroundTilemaps[index].WorldToCell(ball.position);

        if (!backgroundTilemaps[index].HasTile(tilePos))
        {
            outOfBoundsTime += Time.deltaTime;
            if (outOfBoundsTime >= timeToReset)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 0f;
                uiDeathScreen.SetActive(true);
                dead = true;

            }
        }
        else
        {
            outOfBoundsTime = 0f;
        }
        
        if(dead && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
