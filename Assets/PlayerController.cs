using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool IsTouchingGround = false;

    public float MovementSpeed = 100.0f;
    public float MaxSpeed = 16.0f;
    public float JumpForce = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Physics stuff should always go in fixed update 
    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        // GetAxisRaw checks for WASD and arrow key input; horizontal refers to AD/Left and Right
        if(Input.GetAxisRaw("Horizontal") == 1)  // 1 is positive x direction
        {
            // Adding force to our rigid body in the positive x direction
            rb.AddForce(new Vector2(MovementSpeed, 0));
            // Clamp our movement speed to MaxSpeed variable
            if (rb.velocity.x > MaxSpeed)
            {
                rb.velocity = new Vector2(MaxSpeed, rb.velocity.y);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)  // negative x direction
        {
            // Force in the negative x direction
            rb.AddForce(new Vector2(-MovementSpeed, 0));
            // clamping again
            if (rb.velocity.x < -MaxSpeed)
            {
                rb.velocity = new Vector2(-MaxSpeed, rb.velocity.y);
            }
        }
        else
        {
            // immediately set our x velocity to zero when releasing movement key
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void Jump()
    {
        // If we're touching the ground and the jump key is pressed
        if(Input.GetKeyDown(KeyCode.Space) && IsTouchingGround)
        {
            // Add a jump force, set touching ground to false
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsTouchingGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get a vector from the player to the object we have just touched
        Vector2 Direction = (collision.gameObject.transform.position - this.gameObject.transform.position);

        // If we have touched the ground, reset our jump
        if (Direction.y < 0)
        {
            IsTouchingGround = true;
        }

        // Useful for detecting top collisions in the future
        //if (Direction.y > 0)
        //{
        //    Debug.Log("top");
        //}
    }
}
