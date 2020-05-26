using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForce : MonoBehaviour
{
    public float force = 1000f;
    public float radius = 70f;
    public float damage = 10f;
    public GameObject push_particles;

    //Implement ability cost
    public float healthcost = 10f;
    PlayerManager myPlayerManager;

    
    void Start()
    {   
        // get playermanaer
        myPlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    public void AbilityForce()
    {
        //Instantiate effect
        GameObject pusheffect = Instantiate(push_particles, transform.position, Quaternion.identity);
        Destroy(pusheffect, 2f);

        //Ability itself
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var nearByoObject in colliders)
        {
            Rigidbody rb = nearByoObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
                Debug.Log("rb gefunden");
            }
            Target target = nearByoObject.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        // ability cost
        myPlayerManager.changeEnergie(-healthcost);
    }
}
