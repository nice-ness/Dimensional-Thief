using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurretLogic : MonoBehaviour
{

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            LookAt2D(player.transform.position);
            //transform.LookAt(player.GetComponent<Transform>(),Vector3.right);
        }
    }

    void LookAt2D(Vector3 target)
    {
        Vector3 diff = target - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
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
