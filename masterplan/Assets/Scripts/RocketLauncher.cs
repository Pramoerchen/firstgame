using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject RocketToFire;
    public Transform tip;
    public Camera fpsCam;
    public float rocketSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire()
    {
        RaycastHit hit;
        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit);
        GameObject Rocket = Instantiate(RocketToFire, tip.transform.position, transform.rotation);
        Vector3 dir = (fpsCam.transform.forward).normalized;
        Rocket.GetComponent<Rocket>().Setup(dir, rocketSpeed);
    }
}
