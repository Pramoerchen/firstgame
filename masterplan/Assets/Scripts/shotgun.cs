using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public int BulletsShot; // Total bullets show per Shot of the gun
    public float BulletsSpread; // Degrees (0-360) to spread the Bullets
    public GameObject BulletTemplate; // Bullet to fire

    private int pelletFireVel = 40;
    public int maxSpread = 5;

    public Transform tip;

    Camera fpsCam;

    void Awake()
    {
        // if no camera referenced, grab the main camera
        if (!fpsCam)
            fpsCam = Camera.main;
    }

    public void Fire()
    {
        float TotalSpread = BulletsSpread / BulletsShot;
        for (int i = 0; i < BulletsShot; i++)
        {
            // Calculate angle of this bullet
            float spreadA = TotalSpread * (i + 1);
            float spreadB = BulletsSpread / 2.0f;
            float spread = spreadB - spreadA + TotalSpread / 2;
            float angle = fpsCam.transform.eulerAngles.y;

            // Create rotation of bullet
            Quaternion rotation = Quaternion.Euler(new Vector3(0, spread + angle, 0));

            // Create bullet
            GameObject bullet = Instantiate(BulletTemplate, tip.position, rotation);
            
            
            //Add randomness to every bullet direction
            Vector3 dir = transform.forward + new Vector3(Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread));
            bullet.GetComponent<Rigidbody>().AddForce(dir * pelletFireVel);
        }

    }
}
