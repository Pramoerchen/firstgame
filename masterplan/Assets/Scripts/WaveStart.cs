using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    public GameObject objectToDespawn;
    EnemySpawnerScript myEnemySpawner;
    private void Start()
    {
       myEnemySpawner = GetComponent<EnemySpawnerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        myEnemySpawner.isPlayerReady = true;
        objectToDespawn.SetActive(false);
    }
}
