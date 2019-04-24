using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightjewelmo : MonoBehaviour
{
    public GameObject jewel;
    public bool jewelactivity;

    void Update()
    {
        if (jewel.gameObject.activeSelf)
        {
            Vector2 pointA = new Vector2(transform.localPosition.x, 1);
            Vector2 pointB = new Vector2(transform.localPosition.x, 0);
            transform.localPosition = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
        }

        else 
        {
            
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.5f, 0);
            
        }
    }
}
