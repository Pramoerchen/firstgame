using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForce : MonoBehaviour
{
    public float force = 1000f;
    public float radius = 700f;
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Q))
        {
            AbilityForce();
        }
    }
    void AbilityForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var nearByoObject in colliders)
        {
            Rigidbody rb = nearByoObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.position * force);
                Debug.Log("rb gefunden");
            }
            Target target = nearByoObject.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
