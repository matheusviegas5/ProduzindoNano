using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;


    float horizontalMove = 0f;
    public bool jump = false;

    public float runSpeed = 40f;


    void Update()
    {
        if (!Configuration.isPaused)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }


            if ((rb.velocity.y > -0.1 && rb.velocity.y < 0.1) || rb.velocity.y == 0)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
            }

            if (rb.velocity.y > 0.1)
            {
                animator.SetBool("IsJumping", true);
            }

            if (rb.velocity.y < -0.1)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", true);
            }
        }
    }

    private void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
