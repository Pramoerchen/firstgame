using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    PlayerManager myPlayerManager;
    Rigidbody rb;
    public float Damage = 75;
    // Start is called before the first frame update
    
    
    public void Setup(UnityEngine.Vector3 shootdir, float fireballspeed)
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(shootdir * fireballspeed, ForceMode.Impulse);


    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            var player = other.GetComponent<PlayerManager>();
            player.changeHealth(-Damage);
            Destroy(gameObject);
        }
       if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
