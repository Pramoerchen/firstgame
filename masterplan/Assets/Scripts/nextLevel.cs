using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public int LadeLevel;
    PlayerManager myPlayerManager;

    void Awake()
    {
        myPlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        { 
            myPlayerManager.SavePlayer();
            SceneManager.LoadScene(LadeLevel);
        } 
    }
}
