
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem deathEffect;
    
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
        if (deathEffect)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
