using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnAwake : MonoBehaviour
{

    [SerializeField] private string soundname;
    // Start is called before the first frame update
    private void Start()
    {
        if (soundname != null) FindObjectOfType<AudioManager>().Play(soundname);
    }
}
