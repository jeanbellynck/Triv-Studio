using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [Header("Door Sounds")]
    public GameObject sourceObjectDoor;
    public AudioSource wrongGuess;
    public AudioSource correctGuess;

    void Start()
    {
        AudioSource[] audios = sourceObjectDoor.GetComponents<AudioSource>();
        wrongGuess = audios[0];
        correctGuess = audios[1];

       
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
