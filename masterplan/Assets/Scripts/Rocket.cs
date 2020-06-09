using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float ExplosionDamage = 300;
    public float force = 300;
    public float radius = 15;
    public GameObject explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 6f);
    }

    public void Setup(UnityEngine.Vector3 dir, float rocketspeed)
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * rocketspeed, ForceMode.Impulse);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            Explode();
        }
    }
    void Explode()
    {


        GameObject explosionEffect = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(explosionEffect, 5f);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearByoObject in colliders)
        {
            Rigidbody rb = nearByoObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            Target target1 = nearByoObject.GetComponent<Target>();
            Target target2 = nearByoObject.GetComponentInParent<Target>();

            if (target1 != null)
            {
                target1.TakeDamage(ExplosionDamage);
            }
            if (target2 != null)
            {
                target2.TakeDamage(ExplosionDamage);
            }

        }

        Destroy(gameObject);
    }

}
