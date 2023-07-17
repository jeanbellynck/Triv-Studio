using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class CamBoundingBoxController : MonoBehaviour
{

    public LayerMask deathLayer;

    [SerializeField]
    private GameObject followMe;

    [SerializeField]
    private float lowerLimit = 0f;
    
    public float upperLimit = 1000f;
    [SerializeField]
    private bool touchingDeathZone = false;

    private Vector3 newPos;
    private Vector3 followPos;


    // Start is called before the first frame update
    void Start()
    {
        followPos = followMe.transform.position;
        newPos = followPos;
    }

    // Update is called once per frame
    void Update()
    {
        followPos = followMe.transform.position;
        followHorizontal();
        followVertical();


        updatePos();
    }

    private void updatePos()
    {
        transform.position = newPos;
    }

    private void followVertical()
    {

        if (!canMoveVertical()) return;
        if (checkIfTouchingDeathZone())
        {
            // if the Cam touches a death Zone, it only goes up, not down
            newPos.y = Math.Max(followPos.y, transform.position.y);
            touchingDeathZone = true;
        }
        else { 
            newPos.y = followPos.y;
            touchingDeathZone = false;
        }
    }

    private bool checkIfTouchingDeathZone()
    {
        
       return Physics2D.OverlapBox(transform.position - new Vector3(0,10,0), new Vector2(10,10), 0f);
        
    }

    private bool canMoveVertical()
    {
        if (followPos.y + 10 < lowerLimit || followPos.y > upperLimit) return false;

        return true;
    }

    private void followHorizontal()
    {
        if (followMe.transform.position.x < transform.position.x) return;
        
        newPos.x = followMe.transform.position.x;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "DeathZone")
        {
            touchingDeathZone = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "DeathZone")
        {
            touchingDeathZone = false;
        }
    }
}
