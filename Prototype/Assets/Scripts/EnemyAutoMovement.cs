using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAutoMovement : MonoBehaviour
{
    public float move_speed = 100f;

    // Update is called once per frame
    void Update()
    {
        AutoMove();
    }

    void AutoMove()
    {
        transform.Translate(Vector3.left * move_speed * Time.fixedDeltaTime);
    }
}
