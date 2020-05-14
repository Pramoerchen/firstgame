using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{

    Target myTarget;
    bool hasExploded = false;
    public float radius = 5f;
    public float force = 700f;
    public float explosionDamage = 100f;
    public ParticleSystem explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        myTarget = gameObject.GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myTarget.health <= 90 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }
    void Explode()
    {
        explosionEffect.Play();
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
