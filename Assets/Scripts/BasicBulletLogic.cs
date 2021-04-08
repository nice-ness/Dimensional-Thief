using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletLogic : MonoBehaviour
{
    private int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            //For now turn the enemy blue when hit
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //collision.gameObject.GetComponent<EnemyController>().damage();
            //Debug.Log("r: " + Random.Range(0, 255)+  "g: " + Random.Range(0, 255) + "b: " + Random.Range(0, 255));
            Destroy(collision.gameObject);
        }
        
    }
}
