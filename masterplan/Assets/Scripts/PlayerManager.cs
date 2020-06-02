using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Camera fpsCam;
    public HealthBar healthBar;
    public float health;
    public bool godmode;

    //ability bools

    public bool ability_push_isActive = false;
    public bool ability_thunder_isActive = false;
    public bool ability_barrel_isActive = false;
    public bool ability_slowmo_isActive = false;


    //Push abilty
    private PushForce abilty_pushforce;

    //Tunder abilty
    public GameObject thunder_particles;
    public float thunder_range = 100f;

    //Barrel abilty
    public GameObject barrel_tospawn;
    float spawnDistance = 10;

    //SlowMotion ability
    private TimeManager abilty_slowmotion;


    void Awake()
    {
        // if no camera referenced, grab the main camera
        if (!fpsCam)
            fpsCam = Camera.main;
    }


    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth((int)health);


        // Get ability scripts
        abilty_pushforce = GetComponent<PushForce>();
        abilty_slowmotion = GetComponent<TimeManager>();


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

            Die();

        }
    }

    void Die()
    {
        EnemySpawnerScript Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawnerScript>();

        if (Spawner.currentWave >= PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", Spawner.currentWave);
        }

        SceneManager.LoadScene("MainScene");
    }


    public void SavePlayer()
    {
        GameMaster_Controll.Instance.health = health;
    }

    void LoadPlayer()
    {
        health = GameMaster_Controll.Instance.health;
    }

    public void changeEnergie(float change)
    {
        changeHealth(change);
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.SetHealth((int)health);

        if (Input.GetKeyDown(KeyCode.Q) && ability_push_isActive)
        {
            abilty_pushforce.AbilityForce();

        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && ability_thunder_isActive)
        {
           
            Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, thunder_range);
            Instantiate(thunder_particles, hit.point, Quaternion.LookRotation(hit.normal));

        }

        if (Input.GetKeyDown(KeyCode.F) && ability_barrel_isActive)
        {
            Vector3 playerPos = transform.position;
            Vector3 playerDirection = transform.forward;
            Quaternion playerRotation = transform.rotation;
            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
            Instantiate(barrel_tospawn, spawnPos, playerRotation);

        }

        if (Input.GetKeyDown(KeyCode.E) && ability_slowmo_isActive)
        {
            abilty_slowmotion.DoSlowMotion();
        }

    }
}
