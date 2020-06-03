using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenDoor : MonoBehaviour
{
    EnemySpawnerScript myEnemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("EnemySpawner"))
        {
            myEnemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawnerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(myEnemySpawner.currentWave % 5 == 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
