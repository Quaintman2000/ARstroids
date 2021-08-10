using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldsBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxShield(int shieldPower)
    {
        slider.maxValue = shieldPower;
        slider.value = shieldPower;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetShieldPower(int shieldPower)
    {
        slider.value = shieldPower;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
