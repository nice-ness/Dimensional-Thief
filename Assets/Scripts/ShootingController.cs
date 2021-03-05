using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public GameObject bullet, staticbullet;
    Vector3 worldPosition;
    Transform playerLocation;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GetComponent<Transform>();
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Directionial Firing
        if (Input.GetButtonDown("Fire1"))
            ShootBullet();

        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            //ShootBullet(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            ShootBullet(worldPosition);
        }
    }

    void ShootBullet()
    {
        GameObject localBullet = Instantiate(bullet, transform.position, transform.rotation);
        localBullet.GetComponent<BulletController>().setDirection = player.facingLeft;
    }

    void ShootBullet(Vector3 mousePos)
    {

           
        //Right know it shoots from the blue square on the player
        GameObject localBullet = Instantiate(bullet, transform.position, transform.rotation);
        localBullet.GetComponent<BulletController>().directionalShooting();
        Vector3 diff = mousePos - localBullet.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        localBullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

    }
}
