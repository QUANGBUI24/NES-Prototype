using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy bullets outside of camera view
        if (gameObject.tag == "Bullet" && collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        // Destroy bullet and enemy when they collide
        if (gameObject.tag == "Bullet" && collision.gameObject.tag == "Enemy")
        {
            PlayerPrefs.SetInt("PlayerMoney", PlayerPrefs.GetInt("PlayerMoney") + 10);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        // Destroy enemy and subtract player's health when enemy pass the player and gooes behind
        if (gameObject.tag == "Wall" && collision.gameObject.tag == "Enemy")
        {
            PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerHealth") - 5);
            Destroy(collision.gameObject);
        }
    }
}
