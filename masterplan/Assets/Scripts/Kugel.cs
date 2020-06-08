using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Kugel : MonoBehaviour
{
    
    public float Damage = 20;

    // Update is called once per frame

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void Setup(UnityEngine.Vector3 shootdir, float bulletspeed)
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(shootdir * bulletspeed, ForceMode.Impulse);


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            try
            { 
                other.transform.GetComponent<Target>().TakeDamage(Damage); 
            }
            catch
            {
                other.transform.GetComponentInParent<Target>().TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
