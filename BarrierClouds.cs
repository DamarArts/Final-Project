using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierClouds : MonoBehaviour
{
    void Update()
    {

        Vector2 pointA = new Vector3(transform.localPosition.x, 1);
        Vector2 pointB = new Vector3(transform.localPosition.x, 0);
        transform.localPosition = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }
}
