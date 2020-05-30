using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleScript : MonoBehaviour
{
    public int price;
    public string saleText;
    public GameObject myGameobj;
    public bool test;
    // Start is called before the first frame update
    void Start()
    {
        test = myGameobj.GetComponent<Gun>().isBuyed;

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void sell(bool selled)
    {
        myGameobj.SetActive(true);
        Debug.Log(myGameobj.tag);
        test = selled;
    }
}
