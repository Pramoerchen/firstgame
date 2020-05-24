using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setMouseSense : MonoBehaviour
{
    public Slider slider;
    
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("mousesense");
    }
}
