using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnScript : MonoBehaviour
{
    public GameObject Asteroid;
    public float timer = 0.0f;
    public float spawnTime = 3.0f;
    public float randomY = 0.0f;

    // Update is called once per frame
    void Update() // Spawns asteroids at random Y position after the time has been reached
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            randomY = Random.Range(180.0f, 275.0f); // Random Y value for the asteroid to spawn
            Instantiate(Asteroid, new Vector3(this.transform.position.x, randomY, this.transform.position.z), Quaternion.identity);
            timer = 0.0f;

            //Decrease time between asteroids spawning
            if (spawnTime > 1.5f)
            {
                spawnTime -= 0.1f; // Makes spawn rate quicker
            }
                
        }
        
    }
}
