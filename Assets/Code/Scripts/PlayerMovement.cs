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
    [SerializeField] public UnityEvent onPlayerStopDoor;
    [SerializeField] public UnityEvent onPlayerGo;
    [SerializeField] public UnityEvent onPlayerGoDoor;

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

        //https://www.youtube.com/watch?v=55bdhtQzzSA
        int layermask = 1 << 5;
        layermask = -layermask;
        //Vector2 rayOrigin = new Vector3(transform.position.x + 100f, transform.position.y - 20f, 0);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, rayDistance, layermask); //origin, direction, distance
        Debug.Log($"raycast: enter {runEventOnceOnCollisionEnter}, exit {runEventOnceOnCollisionExit}");
        if (hitRight.collider != null)
        {
            Debug.Log($"collider hit: {hitRight.collider.name}");
            if (runEventOnceOnCollisionEnter)
            {
                onPlayerStop?.Invoke();
                runEventOnceOnCollisionEnter = false;
                runEventOnceOnCollisionExit = true;
                Debug.Log($"coll enter: enter {runEventOnceOnCollisionEnter}, exit {runEventOnceOnCollisionExit}");
            }
        }
        else
        {
            if (runEventOnceOnCollisionExit)
            {
                onPlayerGo?.Invoke();
                runEventOnceOnCollisionExit = false;
                runEventOnceOnCollisionEnter = true;
                Debug.Log($"coll exit: enter {runEventOnceOnCollisionEnter}, exit {runEventOnceOnCollisionExit}");
            }
        }
        Debug.DrawRay(transform.position, transform.right * rayDistance, Color.red);

    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(animator.GetFloat("Horizontal"), rb.velocity.y);
        isGrounded = checkGrounded();

        
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