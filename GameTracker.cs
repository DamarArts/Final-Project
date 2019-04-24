using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTracker : MonoBehaviour
{
    public GameObject Player;
    public GameObject Jewel;

    private void OnTriggerEnter2D(Collider2D Jewel)
    {

        if ( Jewel.gameObject == Player.gameObject)
        {
            Jewel.gameObject.SetActive(false);
        }
    }
}
