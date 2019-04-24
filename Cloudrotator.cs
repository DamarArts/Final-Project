using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloudrotator : MonoBehaviour
{
  //  public Transform player;
    //public float offsetx;
  //  public float offsety;
   // public float CloudSmoothing;

    private void LateUpdate()
    {
      // Vector3 CloudPosition = new Vector3(player.position.x + offsetx, offsety, 0);
       // Vector3 SmoothCloud = Vector3.Lerp(transform.position, CloudPosition, CloudSmoothing);
        //transform.position = SmoothCloud;
        transform.Rotate(new Vector3(0, 0, 2f) * Time.deltaTime);
    }
}
