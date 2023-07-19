using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


// inspired by https://www.youtube.com/watch?v=7rCUt6mqqE8, https://www.youtube.com/watch?v=dwcT-Dch0bA
public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]

    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = 5f;
    [SerializeField] private float jumpForce = 10f;  // Amount of force added when the player jumps.
    [SerializeField] private float jumpingHoldMultiplicator = 4f;  // Amount of force added when the player holds jump
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement
    private bool m_AirControl = false;   // Whether or not a player can steer while jumping;

    [Space]


    private Vector3 velocity = Vector3.zero;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask deathLayer;
    private Vector2 groundedBoxSize;


    [Space]
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    [Header("Runtime Variables")]
    [Space]

    public bool moving = true;
    public bool jumpStart = false;
    public bool jumping = false;
    public bool isGrounded = false;
    private bool facingLeft = false;
    public bool turningEnabled = false;    



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundedBoxSize = groundCheck. GetComponent<BoxCollider2D>().size;
        Debug.DrawLine(new Vector3(groundCheck.transform.position.x - (groundedBoxSize.x / 2), groundCheck.transform.position.y,0), new Vector3(groundCheck.transform.position.x + (groundedBoxSize.x / 2), groundCheck.transform.position.y, 0), Color.red);
        rb.gravityScale = gravity;
        if (OnLandEvent == null) OnLandEvent = new UnityEvent();
        
        
    }

    void Start()
    {
        setMoving(true);
        
    }

    void Update()
    {
        updateStatus();
        handleInput();

    }



    private void updateStatus()
    {
        if (checkIfDead())
        {
            die();
        }
    }

    private bool checkIfDead()
    {
        //checks if touching death Zone
        return Physics2D.OverlapBox(groundCheck.transform.position, groundedBoxSize, 0f, deathLayer) || transform.position.y < -60;
    }

    // handles what happens when the player dies
    private void die()
    {
        SceneManager.LoadScene("GameOverDoors");
    }


 

    private void handleInput()
    {
        //if on the ground and jump, then jump
        if (Input.GetButtonDown("Jump") && isGrounded) jumpStart = true;
        if (Input.GetButton("Jump")) jumping = true;
        
    }




    private void FixedUpdate()
    {
        checkIfGrounded();
        if (moving)
        {
            calcMove(speed);
            var g = (!isGrounded || jumpStart) ? gravity : gravity;
            rb.gravityScale = g;

        }
        else if (!moving)
        {
            haltMove();
            
        }

       

    }

    private void calcMove(float horizontalMove)
    {
        // rb.velocity = new Vector2(speed, rb.velocity.y);

        
        
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(horizontalMove * 100f * Time.fixedDeltaTime, rb.velocity.y);
            // And then smoothing it out and applying it to the character
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            /* if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            } */
        

        // If the player should jump...
        if (isGrounded && jumpStart)
        {
            // Add a vertical force to the player.
            rb.AddForce(new Vector2(0f, jumpForce * 100));
            isGrounded = false;
            jumpStart = false;
        }
        if (!isGrounded && jumping && rb.velocity.y > 0.5f)
        {
            rb.AddForce(new Vector2(0f, jumpingHoldMultiplicator * 10));
            jumping = Input.GetButton("Jump");

        }
    }

    public void haltMove()
    {
        if (isGrounded)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(0, rb.velocity.y);
            // And then smoothing it out and applying it to the character
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

        }

    }

    private void checkIfGrounded()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.transform.position, groundedBoxSize, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }


    public void setMoving(bool move)
    {
        moving = move;
    }

}