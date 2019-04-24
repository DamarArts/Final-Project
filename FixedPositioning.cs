using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPositioning : MonoBehaviour
{
    public Transform player;
    public float offsetx;
    public float offsety;
    public float CamSmoothing;

    private void LateUpdate()
    {
        Vector3 CamPosition = new Vector3(player.position.x + offsetx, offsety, 0);
        Vector3 SmoothCam = Vector3.Lerp(transform.position, CamPosition, CamSmoothing);
        transform.position = SmoothCam;

    }
}
