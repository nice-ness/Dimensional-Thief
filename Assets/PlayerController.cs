using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 MovementSpeed;
    public float MaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        MovementSpeed = new Vector2(100.0f, 0.0f);
        MaxSpeed = 8.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Physics stuff should always go in fixed update 
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement() {
        // GetAxisRaw checks for WASD and arrow key input; horizontal refers to AD/Left and Right
        if(Input.GetAxisRaw("Horizontal") == 1)  // 1 is positive x direction
        {
            // Adding force to our rigid body in the positive x direction
            rb.AddForce(MovementSpeed);
            // Clamp our movement speed to MaxSpeed variable
            if (rb.velocity.x > MaxSpeed)
            {
                rb.velocity = new Vector2(MaxSpeed, rb.velocity.y);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)  // negative x direction
        {
            // Force in the negative x direction
            rb.AddForce(-MovementSpeed);
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
}
