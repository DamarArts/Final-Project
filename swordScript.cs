using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    private GameObject sword;
   // public int GhostsSlayed;
    public PlayerControls PlayerControlsScript;
    void Start()
    {
        
       // GhostsSlayed = 0;
        sword = GetComponent<GameObject>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            PlayerControlsScript.Score = PlayerControlsScript.Score + 10;
            PlayerControlsScript.SetAllText();
            PlayerControlsScript.MonsterDeathSound.Play();
        }
    }
}
