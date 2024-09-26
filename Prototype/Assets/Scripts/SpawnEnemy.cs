using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public bool is_auto_spawn = false;
    public GameObject enemy_prefab;
    public Transform spawn_point;
    public float spawn_rate = 1.0f; // Time in seconds between each shot
    private float next_spawn_time = 0f; // Tracks when the gun can shoot next

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyControl();
    }

    void EnemyControl()
    {
        if (Time.time >= next_spawn_time)
        {
            if (is_auto_spawn)
            {
                SpawningEnemy();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    SpawningEnemy();
                }
            }
        } 
    }

    void SpawningEnemy()
    {
        Vector3 spawn_position = spawn_point.position;
        GameObject enemy = Instantiate(enemy_prefab, spawn_position, spawn_point.rotation);
        // Set the next time you are allowed to spawn
        next_spawn_time = Time.time + spawn_rate;
    }
}
