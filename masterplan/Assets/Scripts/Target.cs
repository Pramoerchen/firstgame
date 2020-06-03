
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float max_health = 50f;
    private float heal = 5;
    public GameObject deathParticle;
    public GameObject drop;
    public int dropAmount =1;
    public ParticleSystem dmgParticle;


    PlayerManager myPlayerManager;
    public EnemySpawnerScript spawner;

    void Start()
    {
        myPlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();

        if (GameObject.FindGameObjectWithTag("Spawner"))
        {
            spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawnerScript>();
            health = health * spawner.difficulty;
            max_health = health;
        }
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (dmgParticle)
            dmgParticle.Play();

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
            int i = 1;
            do
            {
                int r = Random.Range(1, 10);
                if (r == 1)
                {
                    GameObject dropSpawn = Instantiate(drop, transform.position, Quaternion.identity);
                    Destroy(dropSpawn, 20f);
                }

                i++;
            } while (i < dropAmount);
            
        }

        myPlayerManager.changeHealth(heal);
        Destroy(gameObject);
    }
}
