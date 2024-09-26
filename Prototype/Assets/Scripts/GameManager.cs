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
    private bool gamePause = false;
    private bool showInstructions = false;
    private int playerHealth;
    private int playerArmor;
    private int playerMoney;


    // Create a custom GUIStyle for the game name
    private GUIStyle titleStyle;

    // Start is called before the first frame update
    void Start()
    {   
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        // Load any player data
        playerHealth = PlayerPrefs.GetInt("PlayerHealth", 100);
        playerArmor = PlayerPrefs.GetInt("PlayerArmor", 0);
        playerMoney = PlayerPrefs.GetInt("PlayerMoney", 0);

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
        // Update player data
        playerHealth = PlayerPrefs.GetInt("PlayerHealth");
        playerArmor = PlayerPrefs.GetInt("PlayerArmor");
        playerMoney = PlayerPrefs.GetInt("PlayerMoney");
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
                    UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
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
                if (!showInstructions) {
                    // Options Menu UI (you can add more options here as needed)
                    GUI.Label(new Rect(centerX - 15, centerY - 100, buttonWidth + 50, buttonHeight), "Options Menu", titleStyle);

                    // Back Button
                    if (GUI.Button(new Rect(centerX, centerY - 50, buttonWidth, buttonHeight), "Back"))
                    {
                        // Return to the main menu
                        showOptions = false;
                    }

                    // Instructions Button
                    if (GUI.Button(new Rect(centerX, centerY + 10, buttonWidth, buttonHeight), "Instructions"))
                    {
                        // Show instructions
                        showInstructions = true;
                    }

                    GUI.Label(new Rect(centerX - 50, centerY + 65, buttonWidth + 50, buttonHeight), "Volume");
                    // Volume Slider
                    GUI.HorizontalSlider(new Rect(centerX, centerY + 70, buttonWidth, buttonHeight), 0.0f, 0.0f, 1.0f);

                } else {
                    // Instructions Menu UI (you can add more instructions here as needed)
                    GUI.Label(new Rect(centerX - 15, centerY - 100, buttonWidth + 50, buttonHeight), "Instructions", titleStyle);
                    GUI.Label(new Rect(centerX - 15, centerY - 60, buttonWidth + 50, buttonHeight), "You have to save your family by finding the cure.");
                    GUI.Label(new Rect(centerX - 15, centerY - 20, buttonWidth + 50, buttonHeight), "Get through all the levels to find it.");
                    GUI.Label(new Rect(centerX - 15, centerY + 20, buttonWidth + 50, buttonHeight), "Get money by killing zombies and upgrade your equipment.");

                    // Back Button
                    if (GUI.Button(new Rect(centerX, centerY + 60, buttonWidth, buttonHeight), "Back"))
                    {
                        // Return to the main menu
                        showInstructions = false;
                    }
                }

            }
        } else if (currentScene == "Level1" || currentScene == "Level2" || currentScene == "Level3" || currentScene == "Level4" || currentScene == "Level5" || currentScene == "Level6") {
            // Game UI
            // Display the game UI here
            if (!gamePause) {
                // show a pause button in the top right corner
                if (GUI.Button(new Rect(Screen.width - 100, 10, 90, 40), "Pause")) {
                    // Pause the game
                    Time.timeScale = 0;
                    gamePause = true;
                }

                // Display the player's health, armor, and money
                GUI.Label(new Rect(10, 10, 200, 20), "Health: " + playerHealth);
                GUI.Label(new Rect(10, 30, 200, 20), "Armor: " + playerArmor);
                GUI.Label(new Rect(10, 50, 200, 20), "Money: " + playerMoney);

            } else {
                if(!showOptions) {
                    // Options Menu UI (you can add more options here as needed)
                    GUI.Label(new Rect(centerX - 15, centerY - 100, buttonWidth + 50, buttonHeight), "Game Paused", titleStyle);

                    // Back Button
                    if (GUI.Button(new Rect(centerX, centerY, buttonWidth, buttonHeight), "Back"))
                    {
                        // Return to the game
                        Time.timeScale = 1;
                        gamePause = false;
                    }

                    // Exit Level Button
                    if (GUI.Button(new Rect(centerX, centerY + 60, buttonWidth, buttonHeight), "Exit Level"))
                    {
                        // Return to the LevelSelect scene
                        Time.timeScale = 1;
                        gamePause = false;
                        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
                    }

                    // Options button
                    if (GUI.Button(new Rect(centerX, centerY + 120, buttonWidth, buttonHeight), "Options"))
                    {
                        // Show options UI
                        showOptions = true;
                    }
                } else {
                    if (!showInstructions) {
                        // Options Menu UI (you can add more options here as needed)
                        GUI.Label(new Rect(centerX - 15, centerY - 100, buttonWidth + 50, buttonHeight), "Options Menu", titleStyle);

                        // Back Button
                        if (GUI.Button(new Rect(centerX, centerY - 50, buttonWidth, buttonHeight), "Back"))
                        {
                            // Return to the main menu
                            showOptions = false;
                        }

                        // Instructions Button
                        if (GUI.Button(new Rect(centerX, centerY + 10, buttonWidth, buttonHeight), "Instructions"))
                        {
                            // Show instructions
                            showInstructions = true;
                        }

                        // Volume Label
                        GUI.Label(new Rect(centerX - 50, centerY + 65, buttonWidth + 50, buttonHeight), "Volume");
                        // Volume Slider
                        GUI.HorizontalSlider(new Rect(centerX, centerY + 70, buttonWidth, buttonHeight), 0.0f, 0.0f, 1.0f);

                    } else {
                        // Instructions Menu UI (you can add more instructions here as needed)
                        GUI.Label(new Rect(centerX - 15, centerY - 100, buttonWidth + 50, buttonHeight), "Instructions", titleStyle);
                        GUI.Label(new Rect(centerX - 15, centerY - 60, buttonWidth + 50, buttonHeight), "You have to save your family by finding the cure.");
                        GUI.Label(new Rect(centerX - 15, centerY - 20, buttonWidth + 50, buttonHeight), "Get through all the levels to find it.");
                        GUI.Label(new Rect(centerX - 15, centerY + 20, buttonWidth + 50, buttonHeight), "Get money by killing zombies and upgrade your equipment.");

                        // Back Button
                        if (GUI.Button(new Rect(centerX, centerY + 60, buttonWidth, buttonHeight), "Back"))
                        {
                            // Return to the options menu
                            showInstructions = false;
                        }
                    }
                }
            }
        } else if (currentScene == "LevelSelect") {
            // Level Select UI
            // Display the level select UI here
            // Level 1 Button
            if (GUI.Button(new Rect(0, centerY + 50, 90, 40), "Level 1"))
            {
                // Load the Level1 scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
            }

            // Level 2 Button
            if (GUI.Button(new Rect((Screen.width / 6), centerY - 50, 90, 40), "Level 2"))
            {
                // Load the Level2 scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
            }

            // Level 3 Button
            if (GUI.Button(new Rect((Screen.width / 6) * 2, centerY + 50, 90, 40), "Level 3"))
            {
                // Load the Level3 scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
            }

            // Level 4 Button
            if (GUI.Button(new Rect((Screen.width / 6) * 3, centerY - 50, 90, 40), "Level 4"))
            {
                // Load the Level4 scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level4");
            }

            // Level 5 Button
            if (GUI.Button(new Rect((Screen.width / 6) * 4, centerY + 50, 90, 40), "Level 5"))
            {
                // Load the Level5 scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level5");
            }

            // Level 6 Button
            if (GUI.Button(new Rect((Screen.width / 6) * 5, centerY - 50, 90, 40), "Level 6"))
            {
                // Load the Level6 scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level6");
            }

            // Back Button
            if (GUI.Button(new Rect(Screen.width - 100, 10, 90, 40), "Back"))
            {
                // Load the main menu scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
            }
        }
    }
}
