using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SetMaxOxygen(int max02)
    {
        slider.maxValue = max02;
        slider.value = max02;
    }

    public void SetOxygen(int o2)
    {
        slider.value = o2;
    }
}
