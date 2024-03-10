using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    
    //public bool canMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalInput, verticalInput).normalized;
        // movement = Quaternion.Euler(0, 0, 30f) * movement;

        
    }

    void FixedUpdate()
    {
        // if(canMove)
        // {
        //     Move();
        // }
        // else
        // {
        //     rb.velocity = Vector2.zero;
        // }
        Move();
    }
    
    private void Move()
    {
        rb.velocity = movement * moveSpeed*Time.deltaTime;
        animator.SetFloat("Speed", rb.velocity.magnitude);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if(movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
