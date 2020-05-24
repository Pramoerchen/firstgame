using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{

    public Text highscore_txt;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
            PlayerPrefs.Save();
        }
    }

        // Update is called once per frame
        void Start()
        {
            highscore_txt.text = PlayerPrefs.GetInt("highscore").ToString();
        }
}
