using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageTrigger : MonoBehaviour
{
    public float damage = 10;
    private float damageTrigger = 1;
    public float damageIntervall = 1;
    public float fireExpanceSpeed = 3f;
    public float maxRange = 20f;
    BoxCollider m_Collider;

    private void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
           float FireArea = 1f + 1*fireExpanceSpeed * Time.time;
            if(FireArea >= maxRange)
            {
                FireArea = maxRange;
            }
            m_Collider.size = new Vector3(1f,1f,FireArea);
        }
        else
        {
            m_Collider.size = new Vector3(1f, 1f, 1f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
  
            Target target = other.GetComponent<Target>();
            if (target != null && Time.time >= damageTrigger)
            {
            Debug.Log("hab nen Gegner gefunden");
            damageTrigger = Time.time + 1f / damageIntervall;
                target.TakeDamage(damage);
            }
    }
}
