using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Animator animator;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    private int extraJumpValue; //for fly if the hero shoot the rope out
    //Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        extraJumpValue = extraJumps;
    }
    
    //Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);

        movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement * speed));
        // Debug.Log(movement);
        if (movement > 0f) //if the movement is forward
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else if (movement < 0f) // go backward
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else //stay idle
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        //Jump Function
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);

            extraJumps = extraJumpValue;
        }
        else
        {
            animator.SetBool("isJumping", true);

        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)//fly
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)//normal jump
        {
            animator.SetTrigger("takeOf");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        Debug.Log(isGrounded);
        //Flip the character if it is moving left
        if (facingRight == false && movement > 0)
        {
            this.Flip();
        }
        else if (facingRight == true && movement < 0)
        {
            this.Flip();
        }
       
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
