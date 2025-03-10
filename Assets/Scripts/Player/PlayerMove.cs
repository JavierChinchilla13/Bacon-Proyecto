using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 3;
    private bool canDoubleJump;

    Rigidbody2D rb2d;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1;

    public SpriteRenderer spriteRenderer;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            if (CheckGround.IsGrounded)
            {
                //PUEDE DAR SALTO DOBLE
                canDoubleJump = true;
                //REALIZA EL SALTO NORMAL
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        //REALIZA DOBLE SALTO
                        rb2d.velocity = new Vector2(rb2d.velocity.x, doubleJumpSpeed);
                        //NO PUEDE DAR DOBLE SALTO
                        canDoubleJump = false;
                    }
                }
            }


        }

        if (CheckGround.IsGrounded == false)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Jump", true);


        }
        else
        {

            animator.SetBool("Jump", false);
            //animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);

            if (Mathf.Round(rb2d.velocity.x) != 0)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }

        }

        if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = true;

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = false;

        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

        }

        //if (Input.GetKey("space") && CheckGround.IsGrounded == true) 
        //{
        //    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        //}

        //if(CheckGround.IsGrounded == false)
        //{
        //    animator.SetBool("Run", false);
        //    animator.SetBool("Jump", true);
        //}
        //else
        //{
        //    animator.SetBool("Jump", false);
        //    if (rb2d.velocity.x != 0) 
        //    {
        //        animator.SetBool("Run", true);
        //    }
        //    else
        //    {
        //        animator.SetBool("Run", false);
        //    }

        //}

        if (betterJump)
        {
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier;
            }

            if (rb2d.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            }
        }


    }
}
