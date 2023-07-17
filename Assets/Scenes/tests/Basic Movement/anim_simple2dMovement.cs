using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simple2dMovement : MonoBehaviour
{
    private UnityEngine.Animator animator;
    private bool facingLeft;
    public PlayerMovement playerMovementScript;

    void Start()
    {
        animator = GetComponent<UnityEngine.Animator>();
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
