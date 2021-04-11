using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRemainingRoom : MonoBehaviour
{
    public LayerMask room;
    public LevelGenerator lg;

    // Update is called once per frame
    void Update()
    {
        // Detect whether a room was spawned here fromt the critical path
        Collider2D detectRoom = Physics2D.OverlapCircle(transform.position, 1.0f, room);
        if (detectRoom == null && lg.stopGen == true)
        {
            //Debug.Log("No room detected, spawning random room");
            int rand = Random.Range(0, lg.rooms.Length);

            Instantiate(lg.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
