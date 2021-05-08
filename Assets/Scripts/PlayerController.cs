using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{//I am notoriously bad at commenting but I am going to try my best
    private const string speedx = "SpeedX", speedY = "SpeedY", grounded = "Grounded";
    private Transform trans;
    private Rigidbody2D rb;
    private bool IsTouchingGround = false;
    [SerializeField]
    Animator anim;
    public float MovementSpeed = 100.0f;
    public float MaxSpeed = 16.0f;
    public float JumpForce = 6.5f;
    public bool doubleJumpActivated = true;
    public bool jumpBoostActivated = true;
    public bool dashPowerActivated = true;
    private float dashCooldown = 0;
    private bool doubleJumpReady;

    [HideInInspector]
    public bool facingLeft { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        facingLeft = false; //Start off facing right
        rb = this.GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        anim = GetComponent<Animator>();//Animation controller
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
        Dash();
        anim.SetBool(grounded, IsTouchingGround);
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.R) && dashCooldown == 0 && dashPowerActivated)
        {
            if (facingLeft)
            {
                rb.AddForce(new Vector2((-MovementSpeed * 6), 0));
                dashCooldown = 5;
            }
            else
            {
                rb.AddForce(new Vector2((MovementSpeed * 6), 0));
                dashCooldown = 5;
            }
        }
        if (dashCooldown > 0)
        {

            dashCooldown -= Time.deltaTime;
            if (dashCooldown <= 0)
            {
                dashCooldown = 0;
            }

        }
    }

    void Movement()
    {
        anim.SetFloat(speedx, Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        // GetAxisRaw checks for WASD and arrow key input; horizontal refers to AD/Left and Right
        if (Input.GetAxisRaw("Horizontal") == 1)  // 1 is positive x direction
        {
            if (facingLeft != false)
                Flip();
            //Tell controller player is moving right
            facingLeft = false;
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
            if (facingLeft != true)
                Flip();
            //Tell controller player is moving left
            facingLeft = true;
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
            rb.velocity = new Vector2(rb.velocity.x - (0.75f * Time.deltaTime), rb.velocity.y);
        }
    }
    void Jump()
    {
        // If we're touching the ground and the jump key is pressed
        /*if(Input.GetKeyDown(KeyCode.Space) && IsTouchingGround)
        {
            // Add a jump force, set touching ground to false
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsTouchingGround = false;
        }*/
        if (!IsTouchingGround && doubleJumpActivated && doubleJumpReady && Input.GetKeyDown(KeyCode.Space))
        {
            //Add a smaller jump force, and disable the double jump.
            if (jumpBoostActivated)
            {
                rb.AddForce(Vector2.up * (JumpForce), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.up * (JumpForce * 0.75f), ForceMode2D.Impulse);
            }

            doubleJumpReady = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsTouchingGround)
        {
            // Add a jump force, set touching ground to false
            if (jumpBoostActivated)
            {
                rb.AddForce(Vector2.up * (JumpForce * 1.25f), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            }

            IsTouchingGround = false;
        }
        anim.SetFloat(speedY, rb.velocity.y);

    }

    /*void Jump()
    {
        // If we're touching the ground and the jump key is pressed
        if(Input.GetKeyDown(KeyCode.Space) && IsTouchingGround)
        {
            // Add a jump force, set touching ground to false
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsTouchingGround = false;
        }
        anim.SetFloat(speedY, rb.velocity.y);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get a vector from the player to the object we have just touched
        Vector2 Direction = (collision.gameObject.transform.position - this.gameObject.transform.position);

        // If we have touched the ground, reset our jump
        if (Direction.y < 0)
        {
            IsTouchingGround = true;
            doubleJumpReady = true;
        }

        // Useful for detecting top collisions in the future
        //if (Direction.y > 0)
        //{
        //    Debug.Log("top");
        //}
    }

    void Flip()
    {
        trans.localScale = new Vector3(trans.localScale.x *-1, trans.localScale.y, trans.localScale.z);
    }
}
