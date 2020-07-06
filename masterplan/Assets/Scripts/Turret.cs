using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float damage = 10f;
    public float fireRate = 2f;
    public float range = 10f;
    Transform myTransform;
    float nextTimeToFire = 1f;
    public ParticleSystem muzzleFlash;
    public ParticleSystem muzzleFlash1;
    PlayerManager myPlayerManager;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        myPlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Searching();
        if(Time.time >= nextTimeToFire)
        {
            Attacking();
        }
             
    }
    void Searching()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (var nearByoObject in colliders)
        {
            var enemy = nearByoObject.GetComponent<Target>();
            if (enemy != null)
            {
                myTransform.LookAt(nearByoObject.transform);
            }
        }
    }
    void Attacking()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
            if(hit.transform.tag == "Enemy"|| hit.transform.tag == "Forcefield")
            {
                hit.transform.GetComponent<Target>().TakeDamage(myPlayerManager.GetDamageWithMultiply(damage));
                muzzleFlash.Play();
                muzzleFlash1.Play();
                nextTimeToFire = Time.time + 1f / fireRate;
            }
    }
}
