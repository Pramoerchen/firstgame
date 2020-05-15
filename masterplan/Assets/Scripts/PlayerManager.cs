using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] private float health;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth((int)health);
    }




    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth((int)health);
    }
}
