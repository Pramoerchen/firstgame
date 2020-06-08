 using UnityEngine;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 100f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public VisualEffect flammen;
    public bool isBuyed;

    public Camera fpsCam;

    void Start()
    {
        if (this.gameObject.name == "Flammenwerfer2")
            flammen.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && this.gameObject.name == "Pistole")
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && this.gameObject.name == "DoubleShotgun")
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if (muzzleFlash)
                muzzleFlash.Play();
            this.gameObject.GetComponent<shotgun>().Fire();
        }

        if (Input.GetButtonDown("Fire1") && this.gameObject.name == "Flammenwerfer2")
        {
            flammen.Play();
        }
        else if (Input.GetButtonUp("Fire1") && this.gameObject.name == "Flammenwerfer2")
        {
            flammen.Stop();
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && this.gameObject.name == "Rifle1.1")
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && this.gameObject.name == "DesertEagle")
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        



    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject ImpacktGo =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpacktGo, 2f);
        }
    }
}
