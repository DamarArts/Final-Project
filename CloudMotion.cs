using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMotion : MonoBehaviour
{
    public float x;
    public float y;
    public float xx;
    public float yy;
    void Update()
    {

        Vector2 pointA = new Vector3(x , y);
        Vector2 pointB = new Vector3(xx , yy);
        transform.localPosition = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }

}
