using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public HealthBar healthBar;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth((int)health);
    }

    public void changeHealth(float change)
    {
        health += change;
        if(health <= 0)
        {
            SceneManager.LoadScene("MainScene");
        }
    }


    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth((int)health);
    }
}
