using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieManager : MonoBehaviour
{
    Target myTarget;
    public HealthBar healthBar;
    [SerializeField] private float health;
    // Start is called before the first frame update
    void Start()
    {
        myTarget = gameObject.GetComponent<Target>();
        
        Debug.Log(myTarget.health);
        healthBar.SetMaxHealth((int)myTarget.health);
    }

    
    

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth((int)myTarget.health);
    }
}
