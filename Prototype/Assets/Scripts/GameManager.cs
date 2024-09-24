using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private string currentScene = "StartMenu";
    // Some variables for button positioning and size (optional, to keep things organized)
    private float buttonWidth = 200;
    private float buttonHeight = 50;
    private bool showOptions = false;


    // Create a custom GUIStyle for the game name
    private GUIStyle titleStyle;

    // Start is called before the first frame update
    void Start()
    {   
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        // Load any player data

        // Play audio

        // Mark objects as DontDestroyOnLoad

        // Create a custom GUIStyle for the game name
        titleStyle = new GUIStyle();
        titleStyle.fontSize = 30;  // Adjust the size as needed
        titleStyle.normal.textColor = Color.white; // Change the color as needed
        titleStyle.fontStyle = FontStyle.Bold; // Bold text
        titleStyle.alignment = TextAnchor.MiddleCenter; // Center the text
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }


    // Save player data
    void SavePlayerData()
    {
        // Save player data
    }

    // GUI function
    void OnGUI()
    {
        // Display GUI depending on scene loaded
        // Define some positions (centered on screen)
        float centerX = (Screen.width / 2) - (buttonWidth / 2);
        float centerY = (Screen.height / 2) - (buttonHeight / 2);

        // Main Menu UI
        if (currentScene == "StartMenu") {
            if (!showOptions)
            {
                // Game Name
                GUI.Label(new Rect(centerX - 15, centerY - 100, buttonWidth + 50, buttonHeight), "Zombie Survival Game", titleStyle);

                // Start Button
                if (GUI.Button(new Rect(centerX, centerY, buttonWidth, buttonHeight), "Start"))
                {
                    // Load the game scene (replace "GameScene" with your scene name)
                    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
                }

                // Options Button
                if (GUI.Button(new Rect(centerX, centerY + 60, buttonWidth, buttonHeight), "Options"))
                {
                    // Show options UI
                    showOptions = true;
                }

                // Exit Button
                if (GUI.Button(new Rect(centerX, centerY + 120, buttonWidth, buttonHeight), "Exit"))
                {
                    // Exit the application (only works in a built game)
                    Application.Quit();
                }
            }
            else
            {
                // Options Menu UI (you can add more options here as needed)
                GUI.Label(new Rect(centerX, centerY - 100, buttonWidth, buttonHeight), "Options Menu");

                // Back Button
                if (GUI.Button(new Rect(centerX, centerY + 60, buttonWidth, buttonHeight), "Back"))
                {
                    // Return to the main menu
                    showOptions = false;
                }
            }
        } else if (currentScene == "SampleScene") {
            // Game UI
            // Display the game UI here
            if (!showOptions) {
                // show a pause button in the top right corner
                if (GUI.Button(new Rect(Screen.width - 100, 10, 90, 40), "Pause")) {
                    // Pause the game
                    Time.timeScale = 0;
                    showOptions = true;
                }
            } else {
                // Options Menu UI (you can add more options here as needed)
                GUI.Label(new Rect(centerX, centerY - 100, buttonWidth, buttonHeight), "Options Menu");

                // Back Button
                if (GUI.Button(new Rect(centerX, centerY + 60, buttonWidth, buttonHeight), "Back"))
                {
                    // Return to the game
                    Time.timeScale = 1;
                    showOptions = false;
                }

                // Exit Level Button
                if (GUI.Button(new Rect(centerX, centerY + 120, buttonWidth, buttonHeight), "Exit Level"))
                {
                    // Load the main menu scene
                    Time.timeScale = 1;
                    showOptions = false;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
                }
            }
        }
    }
}
