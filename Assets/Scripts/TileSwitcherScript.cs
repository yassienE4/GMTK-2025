using UnityEngine;


public class TileSwitcherScript : MonoBehaviour
{
    public GameObject[] tilemapObjects; // Drag Tilemap1, Tilemap2, ... here in order
    private int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnableOnly(currentIndex);
    }
    public void SwitchTo(int index)
    {
        if (index >= 0 && index < tilemapObjects.Length)
        {
            currentIndex = index;
            EnableOnly(index);
        }
    }
    private void EnableOnly(int indexToEnable)
    {
        for (int i = 0; i < tilemapObjects.Length; i++)
        {
            tilemapObjects[i].SetActive(i == indexToEnable);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentIndex = (currentIndex + 1) % tilemapObjects.Length;
            EnableOnly(currentIndex);
        }
    }


   
}
