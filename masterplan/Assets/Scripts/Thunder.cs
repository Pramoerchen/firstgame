using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public float range = 10;
    public float Damage = 5;
    public float duration = 5;
    float timescale = 0f;
    // Start is called before the first frame update
    
    //Implement ability cost
    public float healthcost = 10f;
    PlayerManager myPlayerManager;


    void Start()
    {
        // get playermanaer
        myPlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();


        // ability cost
        myPlayerManager.changeEnergie(-healthcost);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, duration);
        if(Time.time >= timescale)
        {
            timescale = Time.time + 1f;
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            foreach (Collider nearByoObject in colliders)
            {
                Target target = nearByoObject.GetComponent<Target>();
                if (target != null)
                     {
                     target.TakeDamage(Damage);
                     }
            }
        }
    }
}
