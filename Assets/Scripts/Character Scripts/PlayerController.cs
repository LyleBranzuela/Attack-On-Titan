using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Hero specifiedHero;  
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Animator animator;
    private bool facingRight = true;

    private static bool isGrounded;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    private int extraJumpValue; //for fly if the hero shoot the rope out
    private static bool isAttacking;


    public void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        // Adjusts the turn position
        float positionChange = (facingRight) ? transform.position.x - 2.5f : transform.position.x + 2.5f;
        transform.position = new Vector3(positionChange, transform.position.y, transform.position.z);

        facingRight = !facingRight;
    }

    public static bool getIsGrounded()
    {
        return isGrounded;
    }

    // Set is attacking boolean
    public static void setIsAttacking(bool attacking)
    {
        isAttacking = attacking;
    }

    //Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        extraJumpValue = extraJumps;
        isAttacking = false;
    }
    
    //Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);

        movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement * specifiedHero.moveSpeed));
        if (movement > 0f && isAttacking == false) //if the movement is forward
        {
            rigidBody.velocity = new Vector2(movement * specifiedHero.moveSpeed, rigidBody.velocity.y);
        }
        else if (movement < 0f && isAttacking == false) // go backward
        {
            rigidBody.velocity = new Vector2(movement * specifiedHero.moveSpeed, rigidBody.velocity.y);
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
        
        if (Input.GetButtonDown("Jump") && extraJumps == extraJumpValue && isGrounded == true) //normal jump
        {
            animator.SetTrigger("takeOf");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        else if (Input.GetButtonDown("Jump") && extraJumps > 0) //fly
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            extraJumps--;
        }

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

}
