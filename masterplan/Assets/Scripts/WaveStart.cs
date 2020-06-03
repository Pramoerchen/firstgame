using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    GameObject myEnemySpawner;
    private void Start()
    {
        myEnemySpawner = GameObject.FindGameObjectWithTag("Spawner");
    }
    void OnTriggerEnter(Collider other)
    {
        if(myEnemySpawner.GetComponent<EnemySpawnerScript>().currentEnemies == 0)
        { 

            myEnemySpawner.GetComponent<EnemySpawnerScript>().isPlayerReady = false;
        }
    }
}
