using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSounds : MonoBehaviour
{
    public PlayerControls playerscript;

    public AudioClip walk;
    public AudioClip run;
    public AudioSource charsound;

    void Start()
    {
        charsound = GetComponent<AudioSource>();
        charsound.clip = run;
        charsound.Play();
        charsound.Pause();
  
    }
}
