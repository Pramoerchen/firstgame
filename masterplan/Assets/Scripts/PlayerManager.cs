using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public HealthBar healthBar;
    public float health;
    public float energie;
    public bool godmode;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth((int)health);
    }

    public void changeHealth(float change)
    {
        if (godmode)
        {
            return;
        }
        health += change;
        if(health <= 0)
        {

            EnemySpawnerScript Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawnerScript>();

            if (Spawner.currentWave >= PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", Spawner.currentWave);
            }

            SceneManager.LoadScene("MainScene");
        }
    }

    public void changeEnergie(float change)
    {
        health += change;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth((int)health);
    }
}
