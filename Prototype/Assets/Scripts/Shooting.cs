using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool is_auto_shoot = true;
    public GameObject bullet_prefab;
    public Transform gun_transform;
    public float bullet_speed = 20f;  // Speed of the bullet
    public float fire_rate = 1.0f; // Time in seconds between each shot
    private float next_fire_time = 0f; // Tracks when the gun can shoot next

    public float firstRayDistance = 14f;
    public float secondRayDistance = 16f;
    public float firstRayAngle = 20f;
    public float secondRayAngle = 0f;
    private bool canShoot = false; // Flag to control whether the gun can shoot
    private bool isGroundEnemy = false;

    void Update()
    {
        RaycastDetection();
        ShootingControl();
    }

    void ShootingControl()
    {
        // Check if enough time has passed to shoot again
        if (Time.time >= next_fire_time && canShoot)
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
            Vector2 shootDirection;

            // Check if it's an air or ground enemy
            if (isGroundEnemy)
            {
                // Apply force to the right (ground enemies, shoot straight)
                shootDirection = gun_transform.right; // Shooting right (default)
            }
            else
            {
                // Apply force in the direction of the firstRayAngle for air enemies
                shootDirection = new Vector2(Mathf.Cos(firstRayAngle * Mathf.Deg2Rad), Mathf.Sin(firstRayAngle * Mathf.Deg2Rad));
            }

            // Apply force in the calculated direction
            bullet_rigidbody.AddForce(shootDirection * bullet_speed, ForceMode2D.Impulse);
        }

        // Set the next time you are allowed to shoot
        next_fire_time = Time.time + fire_rate;
    }

    void RaycastDetection()
    {
        canShoot = false; // Reset the shoot flag before checking raycasts

        RaycastHit2D hit;

        // Cast a ray at an adjustable angle to the right and draw it
        Vector2 firstDirection = Quaternion.Euler(0, 0, firstRayAngle) * Vector2.right;
        Debug.DrawRay(transform.position, firstDirection * firstRayDistance, Color.red);
        hit = Physics2D.Raycast(transform.position, firstDirection, firstRayDistance);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            isGroundEnemy = false;
            Debug.Log("Hit enemy at " + firstRayAngle + " degrees: " + hit.collider.name);
            canShoot = true; // Allow shooting if an enemy is detected
        }

        Vector2 secondDirection = Quaternion.Euler(0, 0, secondRayAngle) * Vector2.right;
        Debug.DrawRay(transform.position, secondDirection * secondRayDistance, Color.green);
        hit = Physics2D.Raycast(transform.position, secondDirection, secondRayDistance);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            isGroundEnemy = true;
            Debug.Log("Hit enemy at " + secondRayAngle + " degrees: " + hit.collider.name);
            canShoot = true; // Allow shooting if an enemy is detected
        }
    }
}
