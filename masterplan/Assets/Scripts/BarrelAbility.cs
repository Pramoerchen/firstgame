using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAbility : MonoBehaviour
{
    public GameObject objectToSpawn;
    float spawnDistance = 10;


    // Start is called before the first frame update
    void Start()
    {
        
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
        }

    }
}
