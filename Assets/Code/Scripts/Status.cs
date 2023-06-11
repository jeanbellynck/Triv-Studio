using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HPtracker : MonoBehaviour
{
    private float fullhp = 2;
    private float halfhp = 1;
    private float dead = 0;
    public float Status;
    // Start is called before the first frame update
    void Start()
    {
        Status = fullhp;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("name:" + collision.gameObject.name);
        if (collision.gameObject.name == "Door1")
        {
            Status -= 1;
            Debug.Log("Status:"+Status);
        }

        if (Status == -1)
        {
            Status = dead;
        }
        if (Status == dead)
        {
            SceneManager.LoadScene("GameOver");
        }


            
    }
}
