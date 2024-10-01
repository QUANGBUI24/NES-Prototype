using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
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

        // Destroy bullet and decrease enemy health when they collide
        if (gameObject.tag == "Bullet" && collision.gameObject.tag == "Enemy")
        {
            // Get the EnemyStat component from the enemy GameObject
            EnemyStat enemyStat = collision.gameObject.GetComponent<EnemyStat>();
            if (enemyStat != null)
            {
                // Reduce enemy health by the bullet damage
                enemyStat.enemyHealth -= 50; // Adjust this value if needed or retrieve it from a BulletStat script if available

                // Check if enemy health falls below zero
                if (enemyStat.enemyHealth <= 0)
                {
                    // Increase player's money
                    PlayerPrefs.SetInt("PlayerMoney", PlayerPrefs.GetInt("PlayerMoney") + 10);

                    // Destroy the enemy
                    Destroy(collision.gameObject);
                }
            }

            // Destroy the bullet after hitting an enemy
            Destroy(gameObject);
        }

        // Destroy enemy and subtract player's health when enemy passes the player and goes behind
        if (gameObject.tag == "Wall" && collision.gameObject.tag == "Enemy")
        {
            int playerArmor = PlayerPrefs.GetInt("PlayerArmor");
            if (playerArmor > 0)
            {
                PlayerPrefs.SetInt("PlayerArmor", PlayerPrefs.GetInt("PlayerArmor") - 5);
            }
            else
            {
                PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerHealth") - 5);
            }
            Destroy(collision.gameObject);
        }
    }
}
