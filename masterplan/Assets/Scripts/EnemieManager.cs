using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieManager : MonoBehaviour
{
    Target myTarget;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        myTarget = gameObject.GetComponent<Target>(); 
        
    }

    
    

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth((int)myTarget.health);
        healthBar.SetMaxHealth((int)myTarget.max_health);
    }
}
