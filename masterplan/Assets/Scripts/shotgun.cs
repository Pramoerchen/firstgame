using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public int bulletsShot; // Total bullets show per Shot of the gun
    public float totaldamage = 400f;

    public GameObject BulletTemplate; // Bullet to fire

    public float pelletFireVel;

    public Transform tip;

    float maxspread = 0.1f;

    Camera fpsCam;

    PlayerManager myPlayerManager;

    void Awake()
    {
        // if no camera referenced, grab the main camera
        if (!fpsCam)
            fpsCam = Camera.main;
    }

    void Start()
    {
        myPlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    public void Fire()
    {
        for (int i = 0; i < bulletsShot; i++)
        {

            float damageperbullet = myPlayerManager.GetDamageWithMultiply(totaldamage / bulletsShot);

            GameObject bullet = Instantiate(BulletTemplate, fpsCam.transform.position, Quaternion.identity);

            
            Vector3 dir = (fpsCam.transform.forward).normalized;

            Vector3 dir_withspread = dir + new Vector3(Random.Range(-maxspread, maxspread), Random.Range(-maxspread, maxspread), Random.Range(-maxspread, maxspread));

            bullet.GetComponent<Kugel>().Setup(dir_withspread, pelletFireVel, damageperbullet);
            
        }

    }
}
