using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    // Update is called once per frame, inspired by https://www.youtube.com/watch?v=TAGZxRMloyU
    void Update()
    {
        int startX = 26;
        scoreText.text = "Score: " + ((player.position.x - startX)*0.25).ToString("0") + "m";
    }
}
