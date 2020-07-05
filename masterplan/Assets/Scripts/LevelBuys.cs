using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuys : MonoBehaviour
{
    public string saleInfoText;
    public float price;
    public bool isBuyed = false;
    public GameObject gameobjectToSpawn;
    // Start is called before the first frame update
    public void buy()
    {
        Instantiate(gameobjectToSpawn,transform.position, Quaternion.identity);
        isBuyed = true;
        Destroy(gameObject, 0.5f);
    }

}
