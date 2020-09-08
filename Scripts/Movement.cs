using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigidbody;

    //Animation
    public Animator animator;
    Boolean facingRight = true;

    //groundCheck
    public Boolean groundCheck;

    public float speed;
    
    float moveX;
    
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
    
    }


    void Update()
    {
        moveX = Input.GetAxis("Horizontal");


        //Animation
        animator.SetFloat("Speed",Mathf.Abs(moveX));
        animator.SetBool("Ground Check", groundCheck);

    }

    private void FixedUpdate()
    {
        //Functions
        Move();
        FlipAnimation();


    }
    void Move()
    {

        rigidbody.MovePosition(new Vector2(transform.position.x + moveX * speed,transform.position.y));     

    }
    void FlipAnimation()
    {
        //Flipping Player
        if(facingRight && moveX < 0)
        {
            Flip();
        }
        else if(!facingRight && moveX > 0)
        {
            Flip();
        }

        void Flip()
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180f, 0);
        }
       
    }

    
   //Ground Checking
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            groundCheck = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            groundCheck = false;
        }
    }




}
