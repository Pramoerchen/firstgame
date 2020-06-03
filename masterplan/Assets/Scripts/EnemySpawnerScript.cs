using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class EnemySpawnerScript : MonoBehaviour
{
    
    public float SpawnAmount = 1f;
    public float spawnTime = 1f;
    public float spawnDelay = 10f;
    public int maxEnemies = 5;
    public int currentWave = 1;

    //enemies left
    public int currentEnemies;

    public Transform[] spawnPoints;
    public GameObject[] ObjectsToSpawn;
    //Player Wavestart
    public bool isPlayerReady = true;
    //boss
    public GameObject boss_prefab;
    public Transform bossSpawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawningEnemy", spawnTime, spawnDelay);
    }

    void Update()
    {
        GameObject[] currenemyobjects = GameObject.FindGameObjectsWithTag("Enemy");
        currentEnemies = currenemyobjects.Length;
    }

    void SpawningEnemy()
    {

        if (isPlayerReady == true)
        {

            if (currentEnemies == 0)
            {
                if (currentWave % 10 == 0)
                {
                    Instantiate(boss_prefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
                    currentWave++;
                    isPlayerReady = false;
                    return;
                }

                int i = 0;
                do
                {
                    int choosenSpawnpoint = Random.Range(0, spawnPoints.Length);
                    int choosenObject = Random.Range(0, ObjectsToSpawn.Length);

                    Instantiate(ObjectsToSpawn[choosenObject], spawnPoints[choosenSpawnpoint].position, spawnPoints[choosenSpawnpoint].rotation);
                    i++;                    
                    
                    
                } while (i <= SpawnAmount);


                SpawnAmount = currentWave * currentWave/2;
                currentWave++;
                isPlayerReady = false;


            }
            else
            {
                isPlayerReady = false;
                return;
            }
        }
    }
}
