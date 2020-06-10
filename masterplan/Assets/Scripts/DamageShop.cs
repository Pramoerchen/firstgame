using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class DamageShop : MonoBehaviour
{
    //Vars
    public float dmgMultiplyAdding = 0.1f;
    public string infotext;
    public float health_cost = 20f;
    public Text dmgMultiplyText;


    //Static Vars
    PlayerManager myPlayerManager;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    public void add_dmg_multiply()
    {

        myPlayerManager.dmgMultiply += dmgMultiplyAdding;
        dmgMultiplyText.text = (Math.Round(myPlayerManager.dmgMultiply, 1)).ToString();

    }
}
