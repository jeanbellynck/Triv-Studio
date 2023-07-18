using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_simple2dMovement : MonoBehaviour
{
    private Animator animator;
    private bool facingLeft;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        facingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = animator.GetFloat("Horizontal");
        animator.SetBool("Running", (horizontal != 0.0f ? true : false) || (Input.GetAxis("Vertical") != 0.0f ? true : false));

        if (facingLeft && horizontal > 0) facingLeft = false;
        else if (!facingLeft && horizontal < 0) facingLeft = true;

        GetComponent<SpriteRenderer>().flipX = facingLeft;
    }
}
