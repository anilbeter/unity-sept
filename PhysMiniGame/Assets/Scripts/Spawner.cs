using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyCircle;
    public Transform[] spawnPoint;
    private float timer;
    public float spawnDelay;

    void Start()
    {
        // Instantiate(enemyCircle, transform.position, transform.rotation);
        timer = Time.time + spawnDelay;
    }


    void Update()
    {
        if (timer < Time.time)
        {
            // spawn
            int i = Random.Range(0, spawnPoint.Length);
            Instantiate(enemyCircle, spawnPoint[i].position, transform.rotation);
            timer += spawnDelay;
        }
    }
}
