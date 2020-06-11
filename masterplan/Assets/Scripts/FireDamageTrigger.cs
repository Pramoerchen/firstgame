using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageTrigger : MonoBehaviour
{
    public float damage = 10;
    public float damageDuration = 4;
    public float damageIntervall = 1;
    public float fireExpanceSpeed = 3f;
    public float maxRange = 20f;
    BoxCollider m_Collider;
    GameObject ParentofThis;
    public List<GameObject> EnemysToBurn;
    Vector3 partentSaveTransform;
    private bool onFire;

    PlayerManager myPlayerManager;

    private void Start()
    {
        myPlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        damage = myPlayerManager.GetDamageWithMultiply(damage);

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
            ParentofThis.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * FireArea);
        }
        else
        {
            ParentofThis.transform.localScale = new Vector3(0, 0, 0);
        }
    }
   


    private void OnTriggerEnter(Collider other)
    {
        if (!EnemysToBurn.Contains(other.gameObject))
         StartCoroutine(DoFireDamage(damageDuration, 4, damage, other.gameObject));
    }

IEnumerator DoFireDamage(float damageDuration, int damageCount, float damageAmount, GameObject Enemy)
{
    onFire = true;
    int currentCount = 0;
    while (currentCount < damageCount)
    {
        Target target1 = Enemy.GetComponent<Target>();
        Target target2 = Enemy.GetComponentInParent<Target>();

        if (target1 != null)
        {
            target1.TakeDamage(damage);
        }
        if (target2 != null)
        {
            target2.TakeDamage(damage);
        }
            yield return new WaitForSeconds(damageDuration);
            currentCount++;
        }
    onFire = false;
}
}
