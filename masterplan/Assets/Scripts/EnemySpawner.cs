using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public float SpawnAmount = 1;
    public float spawnTime = 1f;
    public float spawnDelay = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawningEnemy", spawnTime, spawnDelay);
    }

    void SpawningEnemy()
    {
        int i = 0;
        do{ 
        Instantiate(ObjectToSpawn, transform.position, transform.rotation);
            i++;
        }while (i <= SpawnAmount);
        SpawnAmount *= 2;
    }
}
