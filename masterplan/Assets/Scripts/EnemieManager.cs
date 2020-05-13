using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieManager : MonoBehaviour
{
    public HealthBar healthBar;
    private float health;
    // Start is called before the first frame update
    void start()

    {
        health = GameObject.Find("Enemie").GetComponent<Target>().health; ;
        Debug.Log(health);
        healthBar.SetMaxHealth((int)health);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth((int)health);
    }
}
