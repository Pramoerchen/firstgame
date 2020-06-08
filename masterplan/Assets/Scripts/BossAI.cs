using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour

    
{
    //Variables
    public GameObject ObjectToShoot;
    public float FireRate = 10f;
    public float SpawnRate = 10f;
    UnityEngine.AI.NavMeshAgent myNavMesh;
    public float checkRate = 0.1f;
    float nextCheck;
    Transform playerTransform;
    private float nextTimeToFire = 0f;
    private float nextTimeToSpawn = 0f;
    public float range = 100f;
    public float FollowRange = 30f;
    public GameObject ObjectToSpawn;
    public float fireball_speed = 15f;

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
        RaycastHit hit;
        Debug.DrawRay(transform.position + new Vector3(0, -1, 0), transform.forward * range);
        if (Physics.Raycast(transform.position + new Vector3 (0, -1, 0), transform.forward, out hit, range))
        {

            if (hit.transform.tag == "Player")
            {
                if (Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / FireRate;
          
                    GameObject fireball = Instantiate(ObjectToShoot, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    Vector3 dir = (transform.forward).normalized;

                    fireball.GetComponent<Fireball>().Setup(dir, fireball_speed);
                }
            }
            else
            {
                if (Time.time >= nextTimeToSpawn)
                {
                    nextTimeToSpawn = Time.time + 1f / SpawnRate;
                    GameObject fireball = Instantiate(ObjectToShoot, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    Vector3 dir = (transform.forward).normalized;

                    fireball.GetComponent<Fireball>().Setup(dir, fireball_speed);
                }
            }

            myNavMesh.transform.LookAt(playerTransform);
            myNavMesh.destination = playerTransform.position;
            
     
        }
        
        
        

        var distance = (transform.position - playerTransform.position).magnitude;
        if (distance < FollowRange)
        {
            myNavMesh.speed = 0;
        }
        else
        {
            myNavMesh.speed = 3.5f;
        }
    }
}
