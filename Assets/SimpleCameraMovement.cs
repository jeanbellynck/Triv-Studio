using System;
using UnityEngine;

public class SimpleCameraMovement : MonoBehaviour
{

    public LayerMask deathLayer;

    [SerializeField]
    private GameObject followMe;
    [SerializeField]
    private Transform groundCheck;

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
        newPos.x = followHorizontal();
        newPos.y = followVertical();
        transform.position = newPos;
    }


    private float followVertical()
    {
        if (followPos.y - groundCheck.position.y < lowerLimit || followPos.y + groundCheck.position.y > upperLimit) return transform.position.y;

        if (touchingDeathZone)
        {
            // if the Cam touches a death Zone, it only goes up, not down
            return Math.Max(followPos.y, transform.position.y);
        }

        return followPos.y;

    }

    private float followHorizontal()
    {
        if (followMe.transform.position.x < transform.position.x) return transform.position.x;

        return followMe.transform.position.x;

    }

    private void FixedUpdate()
    {
        checkIfTouchingDeathZone();
    }

    private bool checkIfTouchingDeathZone()
    {

        return touchingDeathZone = Physics2D.OverlapBox(new Vector2(groundCheck.position.x, groundCheck.position.y), new Vector2(20, 3), 0f, deathLayer);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "DeathZone")
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
