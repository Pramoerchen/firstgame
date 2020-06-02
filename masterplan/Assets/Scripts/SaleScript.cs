using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleScript : MonoBehaviour
{
    public int price;
    public string saleText;
    public GameObject WeaponObjectToUnlock;
    public GameObject playermanager;
    // Start is called before the first frame update
    void Start()
    {
        WeaponObjectToUnlock.SetActive(false);
    }

    // Update is called once per frame

    public void Sell()
    {
        WeaponObjectToUnlock.SetActive(true);
        
        WeaponObjectToUnlock.GetComponent<Gun>().isBuyed = true;
    }
    public void RandomAbilitybuy()
    {
        int i = Random.Range(0, 4);
        
        switch (i)
        {
            case 0:
                playermanager.GetComponent<PlayerManager>().ability_barrel_isActive = true;
                break;
            case 1:
                playermanager.GetComponent<PlayerManager>().ability_push_isActive = true;
                break;
            case 2:
                playermanager.GetComponent<PlayerManager>().ability_slowmo_isActive = true;
                break;
            case 3:
                playermanager.GetComponent<PlayerManager>().ability_thunder_isActive = true;
                break;
        }

    }
}
