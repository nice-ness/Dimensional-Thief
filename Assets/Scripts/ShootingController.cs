using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public GameObject bullet;
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
        if (Input.GetButtonDown("Fire1"))
            ShootBullet();
    }

    void ShootBullet()
    {
        GameObject localBullet = Instantiate(bullet, transform.position, transform.rotation);
        localBullet.GetComponent<BulletController>().setDirection = player.facingLeft;


    }
}
