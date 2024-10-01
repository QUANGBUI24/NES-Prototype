using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    public float enemySpeed = 1f;           // Speed for straight movement
    public float strikeSpeed = 5f;          // Speed for striking towards the player
    public float straightDuration = 8f;      // Time before the enemy starts striking

    public float playerSpeed = 0.5f;          // Speed for player movement
    public bool isMainCharacter = false;   // Flag to determine if this is the player
    public bool isFlyingEnemy = false;     // Flag to determine if this is a flying enemy

    private GameObject player;               // Reference to the player GameObject
    private bool isStriking = false;         // Track whether the enemy is in striking phase
    private Vector3 targetPosition;          // Player's position to strike towards

    void Start()
    {
        // If this is a flying enemy, find the player and start straight movement phase
        if (isFlyingEnemy)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(StraightFlight());
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("GamePaused") != 1)
        {
            AutoMove();
        }
    }

    void AutoMove()
    {
        if (isMainCharacter)
        {
            // Player moves to the right continuously
            transform.Translate(Vector3.right * playerSpeed * Time.fixedDeltaTime);
        }
        else if (isFlyingEnemy)
        {
            if (isStriking)
            {
                // Move towards the player's position when in striking phase
                Vector3 direction = (targetPosition - transform.position).normalized;
                transform.position += direction * strikeSpeed * Time.deltaTime;
            }
            else
            {
                // Move straight left before switching to striking phase
                transform.Translate(Vector3.left * enemySpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            // Normal enemy movement to the left
            transform.Translate(Vector3.left * enemySpeed * Time.fixedDeltaTime);
        }
    }

    IEnumerator StraightFlight()
    {
        // Fly straight for the specified duration
        yield return new WaitForSeconds(straightDuration);

        // Set the striking phase to true
        isStriking = true;

        // Capture the player's current position at the start of the striking phase
        if (player != null)
        {
            targetPosition = player.transform.position;
        }
    }
}
