using System;
using UnityEngine;

public class PlayerAnimator: MonoBehaviour
{
    private Animator animator;
    private bool facingLeft = false;
    private bool facingLeftOld = false;
    private PlayerMovement playerMovementScript;
    private Rigidbody2D rb;
    public GameObject deathSound;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMovementScript = GetComponent<PlayerMovement>();
        updateAnimator();
    }

    // Update is called once per frame
    void Update()
    {
        updateAnimator();
        if (playerMovementScript.turningEnabled) handleTurning();

    }

    private void handleTurning()
    {
        if (facingLeft &&rb.velocity.x > 0) facingLeft = false;
        else if (!facingLeft && rb.velocity.x < 0) facingLeft = true;
    }

    private void FixedUpdate()
    {
        if (playerMovementScript.turningEnabled)
        {
            handleTurningFixed();
        }
        if (playerMovementScript.statusDeath)
        {
            Instantiate(deathSound);
        }
    }

    private void handleTurningFixed()
    {
        if (facingLeftOld != facingLeft)
        {
            // Switch the way the player is labelled as facing.
            facingLeft = !facingLeft;

            // Multiply the player's x local scale by -1.
            /*
            * Vector3 theScale = transform.localScale;
            *   theScale.x *= -1;
            *   transform.localScale = theScale;
            */

            GetComponent<SpriteRenderer>().flipX = facingLeft;
        }
    }

    private void updateAnimator()
    {
        animator.SetFloat("SpeedV", rb.velocity.y);
        animator.SetFloat("SpeedH", rb.velocity.x);
        animator.SetBool("Moving", playerMovementScript.moving);
        animator.SetBool("IsGrounded", playerMovementScript.isGrounded);
        animator.SetBool("Jumping", playerMovementScript.jumping);
        animator.SetBool("IsDead", playerMovementScript.statusDeath);

    }
}
