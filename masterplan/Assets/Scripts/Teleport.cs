using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TeleportTarget;
    public GameObject Player;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Es hat getriggert");
        if (Input.GetKeyDown(KeyCode.T))
        {
            Player.transform.position = TeleportTarget.transform.position;
        }
    }
}
