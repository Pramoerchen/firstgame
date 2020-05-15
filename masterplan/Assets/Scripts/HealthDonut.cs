using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDonut : MonoBehaviour
{
    PlayerManager myPlayerManager;
    public float healAmount = 50;
    Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
     
    }
    private void Update()
    {
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
         if(other.name == "Player")
        {
            var player = other.GetComponent<PlayerManager>();
            player.changeHealth(healAmount);
            Destroy(gameObject);
        }
            
    }
}
