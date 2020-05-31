using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBuy : MonoBehaviour
{
    float range = 100;
    public Camera fpsCam;
    public PlayerManager myPlayerManager;
    public Text mytext;
    // Start is called before the first frame update
    void Start()
    {
        myPlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Buy();
    }
    public void Buy()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            SaleScript sale = hit.transform.GetComponent<SaleScript>();
            if(sale != null)
            {
                mytext.text = sale.saleText;
                if (Input.GetKeyDown(KeyCode.B)&& sale.myGameobj != null)
                {
                    myPlayerManager.changeHealth(-sale.price);
                    sale.Sell();
                    
                }
                if(Input.GetKeyDown(KeyCode.B)&& sale.playermanager != null)
                {
                    myPlayerManager.changeHealth(-sale.price);
                    sale.RandomAbilitybuy();
                }
            }
            else
            {
                mytext.text = null;
            }
        }
    }
}
