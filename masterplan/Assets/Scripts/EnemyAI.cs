using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int ExplosionDmg = 50;
    Transform playerTransform;
    UnityEngine.AI.NavMeshAgent myNavMesh;
    public float checkRate = 0.1f;
    float nextCheck;
    public float radius = 5;
    bool hasExploded = false;
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
        ExplodeAtPlayer();
    }

    void FollowPlayer()
    {
        myNavMesh.transform.LookAt(playerTransform);
        myNavMesh.destination = playerTransform.position;
    }
    void ExplodeAtPlayer()
    {
        //OverlapSphere erstellen um nach Player zu suchen
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var nearByoObject in colliders)
        {
           var player =  nearByoObject.GetComponent<PlayerManager>();
            //Gegner Jagt sich in die Luft sobald Spieler nah genug dran ist und andere objekte in reichweite auch
            if ( player != null && !hasExploded)
            {
                player.GetComponent<PlayerManager>().health -= ExplosionDmg;
                hasExploded = true;
            }
            var enemie = nearByoObject.GetComponent<Target>();
            if(hasExploded)
            {
                enemie.GetComponent<Target>().health -= ExplosionDmg;
            }
        }   
    }
}
