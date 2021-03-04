using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            //For now turn the enemy blue when hit
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //Debug.Log("r: " + Random.Range(0, 255)+  "g: " + Random.Range(0, 255) + "b: " + Random.Range(0, 255));
        }
        
    }
}
