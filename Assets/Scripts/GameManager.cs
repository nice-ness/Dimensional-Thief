using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    public GameObject dummyTarget;
    
    private int maxDummyTargets = 5;
    private int numberTargets = 3;
    private float tickTimer;
    */

    public GameObject PlayerSpawner;    // Position for spawning our player
    public GameObject PlayerPF;         // Player object to spawn

    // Start is called before the first frame update
    void Start()
    {
        // Spawn three targets randomly in our test scene
        /*Instantiate(dummyTarget, new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 3f), 0), Quaternion.identity);
        Instantiate(dummyTarget, new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 3f), 0), Quaternion.identity);
        Instantiate(dummyTarget, new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 3f), 0), Quaternion.identity);*/

        Instantiate(PlayerPF, PlayerPF.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Increment tick timer by elapsed time
        tickTimer += Time.deltaTime;
        if (tickTimer >= 2.0f)  // perform this after 2 seconds:
        {
            if (numberTargets <= maxDummyTargets)  // spawn a new target if we have less than 5
            {
                Instantiate(dummyTarget, new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 3f), 0), Quaternion.identity);
            }
            tickTimer -= 2.0f;  // reset timer
        }
        */
    }
}
