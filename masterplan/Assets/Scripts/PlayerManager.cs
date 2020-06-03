using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    private float start_health = 100f;



    private Camera fpsCam;
    public HealthBar healthBar;
    public float health;
    public float maxhealth;
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

    // weapons

    public GameObject weapon_ar;
    public GameObject weapon_shotgun;
    public GameObject weapon_deagle;

    Gun weapon_deagle_gun;
    Gun weapon_ar_gun;
    Gun weapon_shotgun_gun;


    void Awake()
    {
        // if no camera referenced, grab the main camera
        if (!fpsCam)
            fpsCam = Camera.main;
    }


    // Start is called before the first frame update
    void Start()
    {
        

        // Get ability scripts
        abilty_pushforce = GetComponent<PushForce>();
        abilty_slowmotion = GetComponent<TimeManager>();

        // Get weapons

        weapon_deagle_gun = weapon_deagle.GetComponent<Gun>();
        weapon_ar_gun = weapon_ar.GetComponent<Gun>();
        weapon_shotgun_gun = weapon_shotgun.GetComponent<Gun>();

        LoadPlayer();

        maxhealth = health;

        healthBar.SetMaxHealth((int)maxhealth);

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

        if (health > maxhealth)
        {
            maxhealth = health;
            healthBar.SetMaxHealth((int) maxhealth);
        }

    }

    void Die()
    {
        EnemySpawnerScript Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawnerScript>();

        if (Spawner.currentWave >= PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", Spawner.currentWave);
        }
        reset_player();
        SceneManager.LoadScene("MainScene");
    }

    void reset_player()
    {
        GameMaster_Controll.Instance.health = start_health;

        GameMaster_Controll.Instance.ability_barrel_isActive = false;
        GameMaster_Controll.Instance.ability_push_isActive = false;
        GameMaster_Controll.Instance.ability_slowmo_isActive = false;
        GameMaster_Controll.Instance.ability_thunder_isActive = false;

        GameMaster_Controll.Instance.weapon_deagle_isAcitve = false;
        GameMaster_Controll.Instance.weapon_ar_isAcitve = false;
        GameMaster_Controll.Instance.weapon_shotgun_isAcitve = false;
    }
    
    public void SavePlayer()
    {
        GameMaster_Controll.Instance.health = health;

        GameMaster_Controll.Instance.ability_barrel_isActive = ability_barrel_isActive;
        GameMaster_Controll.Instance.ability_push_isActive = ability_push_isActive;
        GameMaster_Controll.Instance.ability_slowmo_isActive = ability_slowmo_isActive;
        GameMaster_Controll.Instance.ability_thunder_isActive = ability_thunder_isActive;

        
        GameMaster_Controll.Instance.weapon_deagle_isAcitve = weapon_deagle_gun.isBuyed;
        
        GameMaster_Controll.Instance.weapon_ar_isAcitve = weapon_ar_gun.isBuyed;
        
        GameMaster_Controll.Instance.weapon_shotgun_isAcitve = weapon_shotgun_gun.isBuyed;


    }

    void LoadPlayer()
    {
        health = GameMaster_Controll.Instance.health;

        ability_barrel_isActive = GameMaster_Controll.Instance.ability_barrel_isActive;
        ability_push_isActive = GameMaster_Controll.Instance.ability_push_isActive;
        ability_slowmo_isActive = GameMaster_Controll.Instance.ability_slowmo_isActive;
        ability_thunder_isActive = GameMaster_Controll.Instance.ability_thunder_isActive;

      
        weapon_deagle_gun.isBuyed = GameMaster_Controll.Instance.weapon_deagle_isAcitve;

        weapon_shotgun_gun.isBuyed = GameMaster_Controll.Instance.weapon_shotgun_isAcitve;

        weapon_ar_gun.isBuyed = GameMaster_Controll.Instance.weapon_ar_isAcitve;

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
