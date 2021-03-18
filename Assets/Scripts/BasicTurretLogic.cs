using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurretLogic : MonoBehaviour
{

    public float shootDelay = 2;
    public GameObject bullet;
    private GameObject player;


    [SerializeField]
    float timeElapsed;
    // Start is called before the first frame update
    void Awake()
    {
        timeElapsed = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {

            timeElapsed += Time.fixedDeltaTime;
            LookAt2D(player.transform.position);
            //transform.LookAt(player.GetComponent<Transform>(),Vector3.right);
        }
        else
        {
            timeElapsed = 0;
        }
    }

    void LookAt2D(Vector3 target)
    {
        Vector3 diff = target - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        if (timeElapsed > shootDelay)
        {
            timeElapsed = 0;
        ShootBullet(rot_z);
        }
    }

    void ShootBullet(float rot_z)
    {


        //Right now it shoots from the blue square on the player
        GameObject localBullet = Instantiate(bullet, transform.position, transform.rotation);
        localBullet.GetComponent<BulletController>().directionalShooting();
        localBullet.GetComponent<BulletController>().Speed /= 2;
        localBullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        localBullet.GetComponent<SpriteRenderer>().color = Color.red;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            player = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && player != null)
            player = null;
    }
}
