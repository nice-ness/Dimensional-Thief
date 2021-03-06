using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    //Needs shooting delay
    public GameObject bullet;
    Vector3 worldPosition;
    Transform playerLocation;
    PlayerController player;

    [SerializeField]
    [Tooltip("BulletStats is an scriptable object. An easy way to change all the entities damage type while editing.")]
    BulletStats bulletStats;

    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GetComponent<Transform>();
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
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

           
        //Right now it shoots from the blue square on the player
        GameObject localBullet = Instantiate(bullet, transform.position, transform.rotation);
        localBullet.GetComponent<BulletController>().directionalShooting();
        localBullet.GetComponent<BulletController>().setData(bulletStats);
        Vector3 diff = mousePos - localBullet.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        localBullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

    }
}
