using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut_speed : MonoBehaviour
{
    public float speedBonus = 10f;
    public float speedTime = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            var player = other.GetComponent<CharacterMovement>();
            player.speed +=speedBonus;
            StartCoroutine(speed());
            transform.position = transform.position + new Vector3(0, -100, 0);
            Destroy(gameObject, speedTime + 0.5f);
        }

    }
    private IEnumerator speed()
    {
        yield return new WaitForSeconds(speedTime);
         var myPlayer = GameObject.FindGameObjectWithTag("Player");
        myPlayer.GetComponent<CharacterMovement>().speed -= speedBonus;
        
    }

}