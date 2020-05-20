using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingAbilitiy : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnDistance = 10;
    public float Energy = 5;
    public float range = 100f;
    public Camera fpsCam;

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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RaycastHit hit;
            Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);
            Instantiate(objectToSpawn, hit.point, Quaternion.LookRotation(hit.normal));
            // ability cost
            myPlayerManager.changeEnergie(-healthcost);
        }

    }
}
