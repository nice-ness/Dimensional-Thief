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
    private int damage = 1;
    private string teamTag;

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

    public void setData(BulletStats data)
    {
        damage = data.damage;
        Speed = data.speed;
        teamTag = data.teamTag;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != teamTag&&collision.tag != "Untagged"&&collision.GetComponent<HealthController>()&&collision.GetComponent<Collider2D>().isTrigger==false)
        {
            Debug.Log("Teamtag: " + teamTag + "\nCollision Tag: " + collision.tag);
            collision.GetComponent<HealthController>().damage(damage);
            Destroy(this.gameObject);
            //For now turn the enemy blue when hit
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //collision.gameObject.GetComponent<EnemyController>().damage();
            //Debug.Log("r: " + Random.Range(0, 255)+  "g: " + Random.Range(0, 255) + "b: " + Random.Range(0, 255));
            //Destroy(collision.gameObject);
        }

    }
}
