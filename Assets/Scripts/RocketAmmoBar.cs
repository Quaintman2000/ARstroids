using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketAmmoBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxRockets(int rockets)
    {
        slider.maxValue = rockets;
        slider.value = rockets;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetRockets(int rockets)
    {
        slider.value = rockets;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
