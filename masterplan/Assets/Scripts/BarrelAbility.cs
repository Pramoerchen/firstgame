using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAbility : MonoBehaviour
{
    public GameObject objectToSpawn;
    float spawnDistance = 10;

    //Implement ability cost
    public float healthcost = 10f;
    PlayerManager myPlayerManager;


    void Start()
    {
        // get playermanaer
        myPlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(objectToSpawn, spawnPos  , playerRotation);
            // ability cost
            myPlayerManager.changeEnergie(-healthcost);
        }

    }
}
