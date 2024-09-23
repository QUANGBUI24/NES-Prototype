using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        // Load any player data

        // Play audio

        // Mark objects as DontDestroyOnLoad
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Save player data
    public void SavePlayerData()
    {
        // Save player data
    }

    // GUI function
    public void OnGUI()
    {
        // Display GUI depending on scene loaded
    }
}
