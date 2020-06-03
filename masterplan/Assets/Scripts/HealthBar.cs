using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider slider;



    void Awake()
    {
        slider.maxValue = 100;
    }
    


    public void SetMaxHealth(int health)

    {
        slider.maxValue = health;
    }

    public void SetHealth(int health)

    {
        slider.value = health;
    }

}
