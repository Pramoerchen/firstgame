using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setMouseSense : MonoBehaviour
{
    public Slider slider;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("mousesense"))
        {
            PlayerPrefs.SetFloat("mousesense", 100);
            PlayerPrefs.Save();
        }
        
    }

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("mousesense");
    }
}
