using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotation : MonoBehaviour
{
   // public Transform player;
   // public float offsetx;
   // public float offsety;
  // public float Smoothing;

    private void LateUpdate()
    {
       //Vector3 SkyPosition = new Vector3(player.position.x + offsetx, offsety, 0);
      //Vector3 SmoothSky = Vector3.Lerp(transform.position, SkyPosition, Smoothing);
      // transform.position = SkyPosition;
       transform.Rotate(new Vector3(0, 0, 0.5f) * Time.deltaTime);
    }


}
