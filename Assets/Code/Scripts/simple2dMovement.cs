using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simple2dMovement : MonoBehaviour
{
    private Animator animator;
    private bool facingLeft;

    public float speed = 20f;
    private Vector2 motion;

    void Start()
    {
        animator = GetComponent<Animator>();
        facingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        motion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(motion * speed * Time.deltaTime);

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetBool("Running", (Input.GetAxis("Horizontal") != 0.0f ? true : false) || (Input.GetAxis("Vertical") != 0.0f ? true : false));

        if (facingLeft && Input.GetAxis("Horizontal") > 0) facingLeft = false;
        else if (!facingLeft && Input.GetAxis("Horizontal") < 0) facingLeft = true;

        GetComponent<SpriteRenderer>().flipX = facingLeft;
    }
}
