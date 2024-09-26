using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticCar : MonoBehaviour
{
    public float move_speed = 5f;

    // Update is called once per frame
    void Update()
    {
        AutoMove();
    }

    void AutoMove()
    {
        transform.Translate(Vector3.right * move_speed * Time.fixedDeltaTime);
    }
}
