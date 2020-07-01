﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gollem1 : MonoBehaviour
{
    Transform playerTransform;
    public float checkRate = 0.01f;
    float nextCheck;
    public float radius = 9;
    bool AttackReady;
    public float attackDmg = 95f;
    Animator myanimator;
    public float fireRate = 1f;
    float nextTimeToFire;
    Target myTarget;
    public float BreakingPoint = 60f;
    public GameObject MiniGollem;

    // Start is called before the first frame update
    void Start()
    {
        myanimator = GetComponent<Animator>();
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myTarget = GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCheck)
            nextCheck = Time.time + checkRate;
        AttackPlayer();
        if (Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            AttackReady = true;
            myanimator.SetBool("isAttacking", false);
        }
        var lookDir = playerTransform.position - transform.position;
        lookDir.y = 0f; //this is the critical part, this makes the look direction perpendicular to 'up'
        transform.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
        if(myTarget.health < BreakingPoint)
        {
            Instantiate(MiniGollem, transform.position + new Vector3(Random.Range(0f,2f), 1, Random.Range(0f, 2f)), Quaternion.identity);
            Destroy(transform.parent.gameObject, 0.1f);
        }

    }


    void AttackPlayer()
    {
        //OverlapSphere erstellen um nach Player zu suchen

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
