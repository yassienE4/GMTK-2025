using UnityEngine;
using System.Collections; // <-- This gives you IEnumerator



public class TileSwitcherScript : MonoBehaviour
{
    public GameObject[] tilemapObjects; // Drag Tilemap1, Tilemap2, ... here in order
    private int currentIndex = 0;
	public float countdownTime = 10f;
    public float TimerRemaining { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnableOnly(currentIndex);
		StartCoroutine(CountdownLoop());
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
    
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.A))
    //     {
    //         currentIndex = (currentIndex + 1) % tilemapObjects.Length;
    //         EnableOnly(currentIndex);
    //     }
    // }

	IEnumerator CountdownLoop()
    {
        while (true)
        {
            float timer = countdownTime;

            while (timer > 0)
            {
                timer -= Time.deltaTime;
                TimerRemaining = Mathf.Max(0, timer);
                //Debug.Log("Time remaining: " + Mathf.CeilToInt(timer));
                yield return null; // wait a frame
            }

            OnCountdownFinished();
        }
    }

	void OnCountdownFinished()
    {
        currentIndex = (currentIndex + 1) % tilemapObjects.Length;
        EnableOnly(currentIndex);
    }
   
}
