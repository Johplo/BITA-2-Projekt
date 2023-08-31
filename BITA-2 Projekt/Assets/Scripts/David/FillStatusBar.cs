using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public Health PlayerHealth;
    public Image fillImage;
    public Slider slider;

        
    void Awake()
    {
        slider = GetComponent<Slider>();
    }


    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillvalue = PlayerHealth.currentHealth / PlayerHealth.maxHealth;

        if (fillvalue <= slider.maxValue / 3)
        {
            fillImage.color = Color.black; //Critical Contition
        }

        if (fillvalue > slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }

        slider.value = fillvalue;





    }
}
