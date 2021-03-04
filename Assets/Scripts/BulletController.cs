using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool movingLeft = false;
    private Rigidbody2D rb;
    private int direction = 1;//1 for right, 1 for left 
    private bool directional = false;
    private int bulletSpeed = 18;

    public float duration = 5;

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

    public void directionalShooting()
    {
        directional = true;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!directional)
            rb.velocity = new Vector2(bulletSpeed * direction, 0);
        else
        {
            rb.velocity = transform.right * bulletSpeed;

        }

        duration -= Time.deltaTime;//Every fixed update call reduce the duration

        if (duration <= 0)// if duration is less than or equal to 0 destroy the bullet
            Destroy(this.gameObject);
    }

}
