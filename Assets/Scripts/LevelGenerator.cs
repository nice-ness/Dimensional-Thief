using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform StartingPosition;  // where to start the generation
    public GameObject[] rooms;          // array containing room prefabs
    // 0 = Room Left Right
    // 1 = Room Left Right Bottom
    // 2 = Room Left Top Right
    // 3 = Room left Top Right Bottom

    public enum ROOM
    {
        LR,
        LRB,
        LTR,
        LTRB
    };

    private int direction;              // for which direction to start spawning rooms
    public float moveAmount;            // how much to move the origin for the next room

    private float spawnTick;            // 
    public float spawnTime = 1.0f;      // time between spawning a room

    [HideInInspector]
    public float maxX;                  // how far right we are allowed to spawn rooms
    [HideInInspector]
    public float minY;                  // how far down we are allowed to spawn rooms
    [HideInInspector]
    public float maxY;                  // how far up we are allowed to spawn rooms
    private bool stopGen = false;       // continue generating rooms?

    public GameObject g_maxX;
    public GameObject g_minY;
    public GameObject g_maxY;

    // Start is called before the first frame update
    void Start()
    {
        // Grab a random room from our available options
        int RandomRoom = Random.Range(0, rooms.Length);

        // Make the starting position 
        transform.position = StartingPosition.position;

        // Spawn a random at our starting positon with no rotation
        Instantiate(rooms[RandomRoom], transform.position, Quaternion.identity);

        // Choose a random direction to start spawning our dungeon (Up(1,2), right(5), down(3,4))
        direction = Random.Range(1, 6);

        maxY = g_maxY.transform.position.y;
        minY = g_minY.transform.position.y;
        maxX = g_maxX.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Spawning a room roughly every 1 second
        if (spawnTick <= 0.0f && stopGen == false)
        {
            MoveGeneration();
            spawnTick = spawnTime;
        } else
        {
            spawnTick -= Time.deltaTime;
        }
    }

    private void MoveGeneration()
    {
        // Once a cell is generated on the right most wall, stop.
        if (transform.position.x == maxX)
        {
            stopGen = true;
            return;
        }

        // 1 & 2 -- Move up
        // 3 & 4 -- Move down
        // 5 -- Move right

        // Moving up
        if (direction == 1 || direction == 2)
        {
            if (transform.position.y < maxY)  // Are we still allowed to move up?
            {
                //Debug.Log("Successful spawn up");
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + moveAmount);
                transform.position = newPosition;

                int rand = Random.Range(2, 4);

                // Spawn the room 
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);  // roll again

                // Prevent generation from going back down
                if (direction == 3)
                {
                    direction = 1;  // go back up
                }
                else if (direction == 4)
                {
                    direction = 5;  // go right
                }
            }
            else if (transform.position.y == maxY)
            {
                // Go right if we reach the top
                Debug.Log("Reached top, going right");
                direction = 5;
            }
        }
        else if (direction == 3 || direction == 4)  // Move down
        {
            if (transform.position.y > minY)  // Are we still allowed to move down?
            {
                //Debug.Log("Successful spawn down");
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPosition;

                int rand = Random.Range(3, rooms.Length);
                // Spawn the room
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                // This will prevent the generation from moving back up
                direction = Random.Range(3, 6);

                //continue down or go right
                if (direction == 1)
                {
                    direction = 3;  // down
                }
                else if (direction == 2)
                {
                    direction = 5;  // right
                }
            }
            else if (transform.position.y == minY)
            {  // If we can't move down, go right
                Debug.Log("Reached bottom, going right");
                direction = 5;
            }
        }
        else if (direction == 5)  // Move right
        {
            if (transform.position.x < maxX)  // Have we reached the maximum X (the end of the road)?
            {
                //Debug.Log("Successful spawn right");
                Vector2 newPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPosition;

                // Include all rooms with a left and right opening
                int rand = Random.Range(0, rooms.Length);
                // Spawn the room
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                // We have reached the end of our currently set constraints, stop generating
                stopGen = true;
            }
        }

        // Spawn a room randomly from our choices, choose a new random direction
        int RandomRoom = Random.Range(0, rooms.Length);
        //Instantiate(rooms[RandomRoom], transform.position, Quaternion.identity);
        //Debug.Log(direction);
    }
}
