using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Hero specifiedHero;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Animator animator;
    private bool facingRight = true;
    public float CheckRadius;
    private static bool isBlocking;
    private static bool isAttacking;


    // Jump Parameters
    //public float jumpSpeed = 5f;
    //public Transform groundCheck;
    //public LayerMask whatIsGround;
    //public AudioSource jump;
    //private static bool isGrounded;
    //public int extraJumps;
    //private int extraJumpValue; //for fly if the hero shoot the rope out

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

    public static bool getIsBlocking()
    {
        return isBlocking;
    }

    //public static bool getIsGrounded()
    //{
    //    return isGrounded;
    //}

    //public void Play_jump()
    //{
    //    jump.Play();
    //}

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
        //extraJumpValue = extraJumps;
        isAttacking = false;
        isBlocking = false;
    }

    //Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);

        //if (isGrounded == true) //Jump Function
        //{
        //    animator.SetBool("isJumping", false);
        //    extraJumps = extraJumpValue;
        //    Play_jump();
        //}
        //else
        //{
        //    animator.SetBool("isJumping", true);
        //}
        //if (Input.GetButtonDown("Jump") && extraJumps == extraJumpValue && isGrounded == true) //normal jump
        //{
        //    animator.SetTrigger("takeOf");
        //    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        //}
        //else if (Input.GetButtonDown("Jump") && extraJumps > 0) //fly
        //{
        //    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        //    extraJumps--;
        //}

        movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement * specifiedHero.moveSpeed));
        bool isBusyCheck = (isAttacking == false && isBlocking == false);
        if (movement > 0f && isBusyCheck) //if the movement is forward
        {
            rigidBody.velocity = new Vector2(movement * specifiedHero.moveSpeed, rigidBody.velocity.y);
        }
        else if (movement < 0f && isBusyCheck) // go backward
        {
            rigidBody.velocity = new Vector2(movement * specifiedHero.moveSpeed, rigidBody.velocity.y);
        }
        else //stay idle
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        
        // Blocking by pressing Space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isBlocking = false;
            animator.SetBool("isBlocking", false);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            isBlocking = true;
            animator.SetTrigger("block");
            animator.SetBool("isBlocking", true);
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
