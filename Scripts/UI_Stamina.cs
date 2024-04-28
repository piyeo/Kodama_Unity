using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stamina : MonoBehaviour
{
    public Slider staminaSlider;
    public Slider decreaseSlider;

    void Start()
    {
        UpdateStaminaUI();
        UpdateDecreaseUI();
    }

    public void UpdateStaminaUI()
    {
        staminaSlider.maxValue = MountainManager.instance.maxStamina;
        staminaSlider.value = MountainManager.instance.currentStamina;
    }

    public void UpdateDecreaseUI()
    {
        decreaseSlider.maxValue = MountainManager.instance.maxStamina;
        decreaseSlider.value = MountainManager.instance.currentStamina;
    }

    void Update()
    {
        
    }
}
