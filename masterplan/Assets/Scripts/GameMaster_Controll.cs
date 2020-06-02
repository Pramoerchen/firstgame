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
 


}
