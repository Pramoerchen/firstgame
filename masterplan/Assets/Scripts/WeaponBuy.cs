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
            Extraleben_kessel kessel = hit.transform.GetComponent<Extraleben_kessel>();
            DamageShop damageShop = hit.transform.GetComponent<DamageShop>();
            LevelBuys levelBuys = hit.transform.GetComponent<LevelBuys>();

            if (kessel != null)
            {
                mytext.text = kessel.kesselText;

                if (Input.GetKeyDown(KeyCode.B))
                {
                    if (!((myPlayerManager.health - kessel.amount_leben) <= 0))
                    {
                        myPlayerManager.changeHealth(-kessel.amount_leben);
                        kessel.extra_leben(kessel.amount_leben);
                        
                    }
                }

            }

            else if(levelBuys != null)
            {
                mytext.text = levelBuys.saleInfoText;
                Debug.Log(mytext.text);

                if (Input.GetKeyDown(KeyCode.B))
                {
                    if (!((myPlayerManager.health - levelBuys.price) <= 0))
                    {
                        myPlayerManager.changeHealth(-levelBuys.price);
                        levelBuys.buy();
                    }
                }
            }

            else if (damageShop != null)
            {
                mytext.text = damageShop.infotext;
                if ( Input.GetKeyDown(KeyCode.B))
                {
                    if (!((myPlayerManager.health - damageShop.health_cost) <= 0))
                    {
                        myPlayerManager.changeHealth(-damageShop.health_cost);
                        damageShop.add_dmg_multiply();
                    }
                }
            }

            else if(sale != null)
            {
                mytext.text = sale.saleText;
                if (Input.GetKeyDown(KeyCode.B)&& sale.WeaponObjectToUnlock != null)
                {
                    if (!((myPlayerManager.health - sale.price) <= 0))
                    {
                        myPlayerManager.changeHealth(-sale.price);
                        sale.Sell();
                    }
                    
                    
                }
                if(Input.GetKeyDown(KeyCode.B)&& sale.playermanager != null)
                {
                    if (!((myPlayerManager.health - sale.price) <= 0))
                    {
                        myPlayerManager.changeHealth(-sale.price);
                        sale.RandomAbilitybuy();
                    }
                }
            }
            else
            {
                mytext.text = null;
            }
        }
    }
}
