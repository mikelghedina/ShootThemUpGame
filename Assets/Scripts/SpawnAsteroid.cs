using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoints;
    public float spawnTime = 3F;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int asteroidIndex = Random.Range(0, enemy.Length);
        Instantiate(enemy[asteroidIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
