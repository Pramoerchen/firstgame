using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    Target myTarget;
    bool hasExploded = false;


    //abilty settings
    public float radius = 5f;
    public float force = 700f;
    public float explosionDamage = 100f;
    public GameObject explosionParticle;
    
    //Implement ability cost
    public float healthcost = 10f;
    PlayerManager myPlayerManager;


    void Start()
    {
        myTarget = gameObject.GetComponent<Target>();
        
        // get playermanaer
        myPlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myTarget.health < 1000 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }
    void Explode()
    {
        // ability cost
        myPlayerManager.changeEnergie(-healthcost);

        GameObject explosionEffect = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(explosionEffect, 5f);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearByoObject in colliders )
        {
            Rigidbody rb = nearByoObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            Target target = nearByoObject.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(explosionDamage);
            }
        }

        Destroy(gameObject);
    }

}
