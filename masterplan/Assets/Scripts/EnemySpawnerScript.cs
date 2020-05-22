using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerScript : MonoBehaviour
{
    
    public float SpawnAmount = 1;
    public float spawnTime = 1f;
    public float spawnDelay = 10f;
    public int currentWave = 1;
    public Transform[] spawnPoints;
    public GameObject[] ObjectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawningEnemy", spawnTime, spawnDelay);
    }

    void SpawningEnemy()
    {
        
        int i = 0;
        do{
        int choosenSpawnpoint = Random.Range(0, spawnPoints.Length);
        int choosenObject = Random.Range(0, ObjectsToSpawn.Length);
        Instantiate(ObjectsToSpawn[choosenObject], spawnPoints[choosenSpawnpoint].position, spawnPoints[choosenSpawnpoint].rotation);
        i++;
        }while (i <= SpawnAmount);
        SpawnAmount *= 2;
        currentWave++;
        Debug.Log(currentWave);
    }
}
