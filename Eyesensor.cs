using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyesensor : MonoBehaviour
{
    public Transform player;
    public float targetMagnitudeNeg;
    public float targetMagnitudePos;
    public float lookrightx;
    public float lookrighty;
    public float lookleftx;
    public float looklefty;
    public float lookDownx;
    public float lookDowny;


    void Update()
    {

         float bango = (player.transform.position.x * transform.position.x + player.transform.position.y * player.transform.position.y);

        if (bango < targetMagnitudeNeg)
        {  
            transform.localPosition = new Vector2(lookleftx, looklefty);
        }

        else if (bango > targetMagnitudePos)
        {
            transform.localPosition = new Vector2(lookrightx, lookrighty);
        }
        else if ((bango > targetMagnitudeNeg) && (bango < targetMagnitudePos))
            
        {
            transform.localPosition = new Vector2(lookDownx, lookDowny);
        }

    }
}
