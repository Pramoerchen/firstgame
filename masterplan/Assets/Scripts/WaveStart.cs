using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    GameObject objectToDespawn;
    GameObject myEnemySpawner;
    private void Start()
    {
        myEnemySpawner = GameObject.FindGameObjectWithTag("Spawner");
        objectToDespawn = GameObject.FindGameObjectWithTag("Stairs");
    }
    void OnTriggerEnter(Collider other)
    {
        if(!GameObject.FindGameObjectWithTag("Enemy"))
        { 
        myEnemySpawner.GetComponent<EnemySpawnerScript>().isPlayerReady = true;
        }
        objectToDespawn.SetActive(false);
    }
    private void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Enemy"))
        {
            objectToDespawn.SetActive(true);
        }
    }
}
