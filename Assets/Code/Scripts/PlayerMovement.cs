using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal = 0f;
    public float speed = 10f;
    private float jumpingPower = 30f;
    public bool isGrounded = true;
    public UnityEngine.Animator animator;

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
        animator = GetComponent<UnityEngine.Animator>();
    }

    void Update()
    {
        horizontal = speed;

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
        rb.velocity = new Vector2(speed, rb.velocity.y);
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
        speed = speed > 0f ? 0f : 10f;
    }
}