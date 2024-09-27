using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AutoMovement : MonoBehaviour
{
    public float enemy_speed = 3f;
    public float player_speed = 3f;
    public bool is_main_character = false;

    // Update is called once per frame
    void Update()
    {
        AutoMove();
    }

    void AutoMove()
    {
        if (PlayerPrefs.GetInt("GamePaused") != 1) 
        {
            if (!is_main_character)
            {
                transform.Translate(Vector3.left * enemy_speed * Time.fixedDeltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * player_speed * Time.fixedDeltaTime);
            }
        }

        
    }
}
