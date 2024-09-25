using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public float rayDistance = 17f;
    public float firstRayAngle = 20f;  
    public float secondRayAngle = 10f;
    public float thirdRayAngle = 0f;

    void Update()
    {
        RaycastHit2D hit;

        // Cast a ray at an adjustable angle to the right and draw it
        Vector2 firstDirection = Quaternion.Euler(0, 0, firstRayAngle) * Vector2.right;
        Debug.DrawRay(transform.position, firstDirection * rayDistance, Color.red);
        hit = Physics2D.Raycast(transform.position, firstDirection, rayDistance);
        if (hit.collider != null)
        {
            Debug.Log("Hit something at " + firstRayAngle + " degrees: " + hit.collider.name);
        }

        Vector2 secondDirection = Quaternion.Euler(0, 0, secondRayAngle) * Vector2.right;
        // Cast a ray upwards and draw it (default upwards ray)
        Debug.DrawRay(transform.position, secondDirection * rayDistance, Color.green);
        hit = Physics2D.Raycast(transform.position, Vector2.up, rayDistance);
        if (hit.collider != null)
        {
            Debug.Log("Hit something above: " + hit.collider.name);
        }

        Vector2 thirdDirection = Quaternion.Euler(0, 0, thirdRayAngle) * Vector2.right;
        // Cast a ray downwards and draw it (default downwards ray)
        Debug.DrawRay(transform.position, thirdDirection * rayDistance, Color.blue);
        hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance);
        if (hit.collider != null)
        {
            Debug.Log("Hit something below: " + hit.collider.name);
        }
    }
}
