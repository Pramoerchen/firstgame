using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_Controll : MonoBehaviour
{
    public static GameMaster_Controll Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        health = 100f;
    }

    // GLOBAL VARS


    public float health;
    
    public bool ability_push_isActive = false;
    public bool ability_thunder_isActive = false;
    public bool ability_barrel_isActive = false;
    public bool ability_slowmo_isActive = false;

    public bool weapon_deagle_isAcitve = false;
    public bool weapon_ar_isAcitve = false;
    public bool weapon_shotgun_isAcitve = false;



}
