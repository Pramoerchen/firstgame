using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float spawningTime = 10f;
    public GameObject PowerUpToSpawn;

    private void Awake()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawningTime);
            Instantiate(PowerUpToSpawn, transform.position + new Vector3(0, +1, 0), Quaternion.identity);
        }
    }
}
