using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TeleportTarget;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Physics.autoSyncTransforms = false;
            Player.transform.position = TeleportTarget.transform.position;
        Physics.autoSyncTransforms = true;

    }
}
