using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeelePathfinder : MonoBehaviour
{
    Transform playerTransform;
    UnityEngine.AI.NavMeshAgent myNavMesh;
    public float checkRate = 0.01f;
    float nextCheck;
    float nextTimeToFire;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        myNavMesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCheck)
            nextCheck = Time.time + checkRate;
        FollowPlayer();



    }
    void FollowPlayer()
    {
        myNavMesh.destination = playerTransform.position;
    }
}

