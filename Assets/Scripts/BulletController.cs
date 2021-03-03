using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool movingLeft = false;
    private Rigidbody2D rb;
    private int direction = 1;//1 for right, 1 for left 

    private int bulletSpeed = 18; 

    public int Speed
    {
        get
        {
            return bulletSpeed;
        }
        set
        {
            bulletSpeed = value;
        }
    }
    public bool setDirection
    {
        set
        {
            movingLeft = value;
            direction = movingLeft == false ? 1 : -1;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            rb.velocity = new Vector2(bulletSpeed * direction, 0);
        
    }

}
