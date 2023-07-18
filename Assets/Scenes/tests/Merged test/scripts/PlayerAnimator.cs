using UnityEngine;

public class PlayerAnimator: MonoBehaviour
{
    private Animator animator;
    private bool facingLeft;
    public Playermvnt playerMovementScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        facingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Horizontal", playerMovementScript.horizontal);
        animator.SetBool("Running", (playerMovementScript.horizontal != 0.0f ? true : false) || (Input.GetAxis("Vertical") != 0.0f ? true : false));

        if (facingLeft && playerMovementScript.horizontal > 0) facingLeft = false;
        else if (!facingLeft && playerMovementScript.horizontal < 0) facingLeft = true;

        GetComponent<SpriteRenderer>().flipX = facingLeft;
    }
}
