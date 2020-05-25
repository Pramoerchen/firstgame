using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    PlayerManager myPlayerManager;
    Rigidbody rb;
    public float speed = 15;
    public float Damage = 75;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward*speed;
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>());
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
