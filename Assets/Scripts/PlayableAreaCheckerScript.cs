using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayableAreaCheckerScript : MonoBehaviour
{
    [SerializeField] private Tilemap[] backgroundTilemaps;
    [SerializeField] private Transform ball;
    private float outOfBoundsTime = 0f;
    public int index = 0;

    void Update()
    {
        Vector3Int tilePos = backgroundTilemaps[index].WorldToCell(ball.position);

        if (!backgroundTilemaps[index].HasTile(tilePos))
        {
            outOfBoundsTime += Time.deltaTime;
            if (outOfBoundsTime >= 1f)
            {
                Debug.Log("out of bounds you died");
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
