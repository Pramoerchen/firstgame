using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiderweb : MonoBehaviour
{
    
    CharacterMovement myCharMovement;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           myCharMovement =  other.GetComponent<CharacterMovement>();
            myCharMovement.speed = myCharMovement.speed / 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myCharMovement = other.GetComponent<CharacterMovement>();
            myCharMovement.speed = myCharMovement.speed * 2;
        }
    }
}
