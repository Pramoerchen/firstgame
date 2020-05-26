using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UI : MonoBehaviour
{
    GameObject ability_1;
    GameObject ability_2;
    GameObject ability_3;
    GameObject ability_4;

    PlayerManager myPlayerManager;

    void Awake()
    {
        ability_1 = GameObject.Find("ability1");
        ability_2 = GameObject.Find("ability2");
        ability_3 = GameObject.Find("ability3");
        ability_4 = GameObject.Find("ability4");
        myPlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();

    }


  
    void Update()
    {

        if (myPlayerManager.ability_push_isActive)
        {
            ability_1.SetActive(true);
        }
        else
        {
            ability_1.SetActive(false);
        }

        if (myPlayerManager.ability_barrel_isActive)
        {
            ability_2.SetActive(true);
        }
        else
        {
            ability_2.SetActive(false);
        }

        if (myPlayerManager.ability_thunder_isActive)
        {
            ability_3.SetActive(true);
        }
        else
        {
            ability_3.SetActive(false);
        }

        if (myPlayerManager.ability_slowmo_isActive)
        {
            ability_4.SetActive(true);
        }
        else
        {
            ability_4.SetActive(false);
        }


    }


}
