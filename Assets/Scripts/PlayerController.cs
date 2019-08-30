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
    //Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    //Update is called once per frame
    void Update()
    {
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

        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
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

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        
    }

}
