using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask deathLayer;

    private Animator animator;


    private bool moving = true;
    public bool isGrounded = true;


    public float horizontalSpeed = 10f;
    private float jumpingPower = 30f;

    private bool facingLeft = false;
    public bool turningEnabled = false;




    void Start()
    {
        startMoving();
        animator = GetComponent<Animator>();
        animator.SetFloat("Horizontal", horizontalSpeed);
    }

    public void startMoving()
    {
        moving = true;


    }

    public void stopMoving()
    {
        moving = false;
        rb.velocity = new Vector2(0f, rb.velocity.y);

    }

    void Update()
    {
        updateStatus();
        handleInput();
        updateAnimator();
        animate();

    }

    private void animate()
    {
        if (turningEnabled) 
        {
            if (facingLeft && horizontalSpeed > 0) facingLeft = false;
            else if (!facingLeft && horizontalSpeed < 0) facingLeft = true;

            GetComponent<SpriteRenderer>().flipX = facingLeft;
        }
        
    }

    private void updateAnimator()
    {
        animator.SetFloat("SpeedV", rb.velocity.y);
        animator.SetFloat("SpeedH", rb.velocity.x);
        animator.SetBool("Moving", moving);
        animator.SetBool("IsGrounded", isGrounded);

    }

    private void updateStatus()
    {
        if (checkIfDead())
        {
            die();
        }
    }

    private void die()
    {
        SceneManager.LoadScene("GameOverDoors");
    }

    private bool checkIfDead()
    {
        //checks if touching death Zone
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, deathLayer);
    }
 

    private void handleInput()
    {
        handleJump();
    }

    private void handleJump()
    {
        //if on the ground and jump, then jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            rb.AddRelativeForce(new Vector2(0f, 10f));
        }
        //start falling if button is released
        else if (Input.GetButtonUp("Jump") && !isGrounded && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f * Time.deltaTime);
        }
    }


    private void FixedUpdate()
    {
        if (moving)
        {
            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);

        }
        isGrounded = checkIfGrounded();
        
    }

    private bool checkIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
    }



    public void toggleMoving()
    {
        var horizontal = animator.GetFloat("Horizontal");
        animator.SetFloat("Horizontal", horizontal > 0f ? 0f : 10f);
    }
}