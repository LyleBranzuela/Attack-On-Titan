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
    private int initialArmor;
    public GameObject guardObject;

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
        initialArmor = specifiedHero.armor;
    }

    //Update is called once per frame
    void Update()
    {
        // Movement for left and right (X-Axis)
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
            specifiedHero.armor = initialArmor;
            isBlocking = false;
            animator.SetBool("isBlocking", false);
            guardObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            specifiedHero.armor = 100;
            isBlocking = true;
            animator.SetTrigger("block");
            animator.SetBool("isBlocking", true);
            guardObject.SetActive(true);
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
