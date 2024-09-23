using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool is_auto_shoot = false;
    public GameObject bullet_prefab;
    public Transform gun_transform;
    public float bullet_speed = 20f;  // Speed of the bullet
    public float fire_rate = 1.0f; // Time in seconds between each shot
    private float next_fire_time = 0f; // Tracks when the gun can shoot next

    void Update()
    {
        ShootingControl();
    }

    void ShootingControl()
    {
        // Check if enough time has passed to shoot again
        if (Time.time >= next_fire_time)
        {
            if (is_auto_shoot)
            {
                FireBullet();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    FireBullet();
                }
            }
        }
    }

    void FireBullet()
    {
        // Instantiate the bullet at the gun position
        GameObject bullet = Instantiate(bullet_prefab, gun_transform.position, gun_transform.rotation);

        // Get the Rigidbody2D of the bullet and apply force to move it forward
        Rigidbody2D bullet_rigidbody = bullet.GetComponent<Rigidbody2D>();

        if (bullet_rigidbody != null)
        {
            // Apply force in the right direction (assuming gun faces right)
            bullet_rigidbody.AddForce(gun_transform.right * bullet_speed, ForceMode2D.Impulse);
        }

        // Set the next time you are allowed to shoot
        next_fire_time = Time.time + fire_rate;
    }
}
