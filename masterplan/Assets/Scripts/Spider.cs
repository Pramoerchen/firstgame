using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    Transform playerTransform;
    UnityEngine.AI.NavMeshAgent myNavMesh;
    public float checkRate = 0.1f;
    float nextCheck;
    public float radius = 5;
    bool AttackReady;
    public float attackDmg = 20f;
    Animator myanimator;
    public float fireRate = 1f;
    float nextTimeToFire;

    // Start is called before the first frame update
    void Start()
    {
        myanimator = GetComponent<Animator>();
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
        AttackPlayer();
        if (Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            AttackReady = true;
            myanimator.SetBool("isAttacking", false);
        }


    }
    void FollowPlayer()
    {
        myNavMesh.transform.LookAt(playerTransform);
        myNavMesh.destination = playerTransform.position;
    }

    void AttackPlayer()
    {
        //OverlapSphere erstellen um nach Player zu suchen
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                foreach (var nearByoObject in colliders)
                {
                    var player = nearByoObject.GetComponent<PlayerManager>();
                    if (player != null && AttackReady)
                    {
                        Debug.Log("Spieler wird von der Spinne gefunden!");
                        player.GetComponent<PlayerManager>().changeHealth(-attackDmg);
                        myanimator.SetBool("isAttacking", true);
                        AttackReady = false;
                    }
                }
            }
        }
    }
}
