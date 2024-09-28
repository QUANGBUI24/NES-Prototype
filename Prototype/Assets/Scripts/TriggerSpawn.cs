using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public float triggerRayDistance = 14f;
    public float triggerRayAngle = 0f;
    public GameObject spawningObject1;
    public GameObject spawningObject2;
    public GameObject spawningObject3;
    public GameObject spawningObject4;

    void Start()
    {
        spawningObject1.SetActive(true);
        spawningObject2.SetActive(false);
        spawningObject3.SetActive(false);
        spawningObject4.SetActive(false);
    }

    void Update()
    {
        RayCastTrigger();
    }

    void RayCastTrigger()
    {
        RaycastHit2D hit;
        Vector2 firstDirection = Quaternion.Euler(0, 0, triggerRayAngle) * Vector2.right;
        Debug.DrawRay(transform.position, firstDirection * triggerRayDistance, Color.cyan);
        hit = Physics2D.Raycast(transform.position, firstDirection, triggerRayDistance);
        if (hit.collider != null && hit.collider.CompareTag("CheckPoint"))
        {
            spawningObject2.SetActive(true);
            spawningObject1.SetActive(false);
            Debug.Log("First Check Point!");
        }
        else if(hit.collider != null && hit.collider.CompareTag("CheckPoint2"))
        {
            spawningObject3.SetActive(true);
            spawningObject2.SetActive(false);
            Debug.Log("Second Check Point!");
        }
        else if (hit.collider != null && hit.collider.CompareTag("CheckPoint3"))
        {
            spawningObject4.SetActive(true);
            spawningObject3.SetActive(false);
            Debug.Log("Third Check Point!");
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(gameObject.tag == "Player")
    //    {
    //        if (collision.gameObject.tag == "CheckPoint")
    //        {
    //            spawningObject2.SetActive(true);
    //            spawningObject1.SetActive(false);
    //            Debug.Log("First Check Point!");
    //        }
    //        else if (collision.gameObject.tag == "CheckPoint2")
    //        {
    //            spawningObject3.SetActive(true);
    //            spawningObject2.SetActive(false);
    //            Debug.Log("Second Check Point!");
    //        }
    //        else if (collision.gameObject.tag == "CheckPoint3")
    //        {
    //            spawningObject4.SetActive(true);
    //            spawningObject3.SetActive(false);
    //            Debug.Log("Third Check Point!");
    //        }
    //    }

    //}
}
