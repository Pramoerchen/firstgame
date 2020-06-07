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
    GameObject ParentofThis;
    public List<GameObject> EnemysToBurn;
    Vector3 partentSaveTransform;

    private void Start()
    {
        //Fetch the Collider from the GameObject
        ParentofThis = transform.parent.gameObject;
        m_Collider = GetComponent<BoxCollider>();
        EnemysToBurn = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            float FireArea = 1 * fireExpanceSpeed * Time.time;
            if (FireArea >= maxRange)
            {
                FireArea = maxRange;
            }
            ParentofThis.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y,transform.localScale.z * FireArea);
        }
        else
        {
            ParentofThis.transform.localScale= new Vector3(0,0,0);
        }
 
        
        
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
