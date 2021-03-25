using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] walls;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, walls.Length);
        Instantiate(walls[rand], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
