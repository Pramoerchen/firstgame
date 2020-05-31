using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleScript : MonoBehaviour
{
    public int price;
    public string saleText;
    public GameObject myGameobj;
    // Start is called before the first frame update
    void Start()
    {
        myGameobj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Sell()
    {
        myGameobj.SetActive(true);
        Debug.Log(myGameobj.tag);
        myGameobj.GetComponent<Gun>().isBuyed = true;
    }
}
