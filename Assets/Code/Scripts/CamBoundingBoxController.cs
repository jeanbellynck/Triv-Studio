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
    private float lowerLimit = -10f;
    [SerializeField]
    private float upperLimit = 1000f;
    [SerializeField]
    private float verticalDisplacement = 5f;
    [SerializeField]
    private float horizontalDisplacement = 0f;
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
        followPos = followMe.transform.position - new Vector3(horizontalDisplacement, verticalDisplacement, 0);
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

        if (!canMoveVertical()) {
            newPos.y = transform.position.y;
            return;

        }
        checkIfTouchingDeathZone();
        if (touchingDeathZone)
        {
            // if the Cam touches a death Zone, it only goes up, not down
            newPos.y = Math.Max(followPos.y, transform.position.y);
      
        }
        else 
        { 
            newPos.y = followPos.y;
        }
    }

    private bool checkIfTouchingDeathZone()
    {
        
       return touchingDeathZone = Physics2D.OverlapBox(transform.position - new Vector3(0,10,0), new Vector2(20,3), 0f, deathLayer );
        
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
