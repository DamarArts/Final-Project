using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private Rigidbody2D enemy;
    private GameObject player;
    private AudioSource MonsterAudio;
    void Start()
    {
        MonsterAudio = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        enemy = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude > 100)
        {
            MonsterAudio.Play();
        }

    }

}