using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Contains all enemy types
    public GameObject[] enemies;

    void Start()
    {
        // Random chance of an enemy spawning as well as a randomly selected enemy
        int randChance = Random.Range(0, 101);
        int randEnemy = Random.Range(0, enemies.Length);

        if(randChance % 3 == 0)
        {
            Instantiate(enemies[randEnemy], transform.position, Quaternion.identity);
        }
    }
}
