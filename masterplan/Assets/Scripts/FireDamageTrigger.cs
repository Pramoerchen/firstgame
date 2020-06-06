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
    public List<GameObject> EnemysToBurn;

    private void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<BoxCollider>();
        EnemysToBurn = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            m_Collider.gameObject.SetActive(true);
        }
        else
        {
            m_Collider.gameObject.SetActive(false);
        }
 
        
        {
            foreach (var Enemy in EnemysToBurn)
            {
               
                if(Enemy == null)
                {
                    EnemysToBurn.Remove(Enemy);
                }
                Target myTarget = Enemy.GetComponent<Target>();

                if(myTarget != null)
                { 
                    myTarget.TakeDamage(damage);
            }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!EnemysToBurn.Contains(other.gameObject))
            EnemysToBurn.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (EnemysToBurn.Contains(other.gameObject))
            EnemysToBurn.Remove(other.gameObject);
    }
}
