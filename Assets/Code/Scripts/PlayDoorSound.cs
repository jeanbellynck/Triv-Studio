using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDoorSound : MonoBehaviour
{
    [Header("Door Sounds")]
    public GameObject sourceObjectDoor; // the gameObject you have the AudioSource files on that you want to play
    public AudioSource wrongGuess;
    public AudioSource correctGuess;

    void Start()
    {
        AudioSource[] doorAudios = sourceObjectDoor.GetComponents<AudioSource>();
        wrongGuess = doorAudios[0];
        correctGuess = doorAudios[1];

       
    }
    public void playWrongGuessSound()
    {
        wrongGuess.Play();
    }

    public void playCorrectGuessSound()
    {
        correctGuess.Play();
    }
}
