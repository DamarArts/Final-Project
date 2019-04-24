using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    void Update()
    {
        
        Vector2 pointA = new Vector3(3, 1);
        Vector2 pointB = new Vector3(0, 0);
        transform.localPosition = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));


        if ((transform.localPosition.x == 0) || (transform.localPosition.x == 3))
        {

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }


}
