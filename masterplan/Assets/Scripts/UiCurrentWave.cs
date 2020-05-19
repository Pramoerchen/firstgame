using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCurrentWave : MonoBehaviour
{
    Text mytext;
    EnemySpawnerScript myEnemySpawner;
    public int wave;
    
    // Start is called before the first frame update
    void Start()
    {
        mytext = GetComponent<Text>();
        myEnemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawnerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        wave = myEnemySpawner.currentWave;
        mytext.text = $"Wave: {wave}";
    }
}
