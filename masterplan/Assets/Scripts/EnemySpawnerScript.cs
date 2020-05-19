using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public float SpawnAmount = 1;
    public float spawnTime = 1f;
    public float spawnDelay = 10f;
    public int currentWave = 1;

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
        currentWave++;
        Debug.Log(currentWave);
    }
}
