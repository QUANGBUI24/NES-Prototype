using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    public float enemy_speed = 3f;           // Speed for straight movement
    public float strike_speed = 5f;          // Speed for striking towards the player
    public float straightDuration = 8f;      // Time before the enemy starts striking

    public float player_speed = 3f;          // Speed for player movement
    public bool is_main_character = false;   // Flag to determine if this is the player
    public bool is_flying_enemy = false;     // Flag to determine if this is a flying enemy

    private GameObject player;               // Reference to the player GameObject
    private bool isStriking = false;         // Track whether the enemy is in striking phase
    private Vector3 targetPosition;          // Player's position to strike towards

    void Start()
    {
        // If this is a flying enemy, find the player and start straight movement phase
        if (is_flying_enemy)
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
        if (is_main_character)
        {
            // Player moves to the right continuously
            transform.Translate(Vector3.right * player_speed * Time.fixedDeltaTime);
        }
        else if (is_flying_enemy)
        {
            if (isStriking)
            {
                // Move towards the player's position when in striking phase
                Vector3 direction = (targetPosition - transform.position).normalized;
                transform.position += direction * strike_speed * Time.deltaTime;
            }
            else
            {
                // Move straight left before switching to striking phase
                transform.Translate(Vector3.left * enemy_speed * Time.fixedDeltaTime);
            }
        }
        else
        {
            // Normal enemy movement to the left
            transform.Translate(Vector3.left * enemy_speed * Time.fixedDeltaTime);
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
