
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject deathParticle;
    
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
        Destroy(gameObject);
    }
}
