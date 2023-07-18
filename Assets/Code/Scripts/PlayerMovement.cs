using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal = 0f;
    private float jumpingPower = 30f;
    public bool isGrounded = true;
    public Animator animator;

    public float rayDistance;
    private bool runEventOnceOnCollisionEnter = true;
    private bool runEventOnceOnCollisionExit = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] public UnityEvent onPlayerStop;
    [SerializeField] public UnityEvent onPlayerGo;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("Horizontal", horizontal);
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            animator.SetBool("isJumping", false);
        }
       
    }

    private void FixedUpdate()
    {
        
        //horizontal = speed;
        rb.velocity = new Vector2(animator.GetFloat("Horizontal"), rb.velocity.y);
        isGrounded = checkGrounded();

        //https://www.youtube.com/watch?v=55bdhtQzzSA
        int layermask = 1 << 5;
        layermask = -layermask;
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, rayDistance, layermask);
        if (hitRight.collider != null)
        {
            if (runEventOnceOnCollisionEnter)
            {
                onPlayerStop?.Invoke();
                runEventOnceOnCollisionEnter = false;
                runEventOnceOnCollisionExit = true;
            }
        }
        else
        {
            if (runEventOnceOnCollisionExit)
            {
                onPlayerGo?.Invoke();
                runEventOnceOnCollisionExit = false;
                runEventOnceOnCollisionEnter = true;
            }
        }

        Debug.DrawRay(transform.position, transform.right * rayDistance, Color.red);
    }

    private bool checkGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
    }

    public void playerGoOrStop()
    {
        var horizontal = animator.GetFloat("Horizontal");
        animator.SetFloat("Horizontal", horizontal > 0f ? 0f : 10f);
    }
}