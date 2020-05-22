
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private float heal = 5;
    public GameObject deathParticle;
    public GameObject drop;

    PlayerManager myPlayerManager;

    void Start()
    {
        myPlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (deathParticle)
        {
           GameObject deathEffekt =  Instantiate(deathParticle, transform.position, Quaternion.identity);
           Destroy(deathEffekt, 5f);
        }

        if (drop)
        {
            int r = Random.Range(1, 10);
            if (r == 1)
            {
                GameObject dropSpawn = Instantiate(drop, transform.position, Quaternion.identity);
                Destroy(dropSpawn, 20f);
            }
            
        }

        myPlayerManager.changeHealth(heal);
        Destroy(gameObject);
    }
}
