using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extraleben_kessel : MonoBehaviour
{

    public string kesselText;
    public float amount_leben;
    public float lebenimkessel;
    float amountForExtraLife = 100f;

    PlayerManager myPlayerManager;

    void Start()
    {
        myPlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // wenn x(gespendetes leben) = y(nötiges leben für extra leben) füge ein extra leben zu player hinzu
    public void extra_leben(float opfer)
    {
        lebenimkessel += opfer;
        if (lebenimkessel == amountForExtraLife)
        {
            myPlayerManager.extralife += 1;
            lebenimkessel = 0;
        }
        Debug.Log(lebenimkessel);
    }

}
