using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class NewUI_VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public string parameter;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float multiplier;

    public void SliderValue(float _value)
    {
        audioMixer.SetFloat(parameter, Mathf.Log10(_value) * multiplier);
        if (parameter == "bgm")
            AudioManager.instance.bgmSliderValue = slider.value;
        if (parameter == "sfx")
            AudioManager.instance.sfxSliderValue = slider.value;
    }

    public void LoadSlider(float _value)
    {
        if (_value >= 0.001f)
            slider.value = _value;
    }
    public void Start()
    {
        if(parameter == "bgm")
             slider.value = AudioManager.instance.bgmSliderValue;
        if(parameter == "sfx")
            slider.value = AudioManager.instance.sfxSliderValue;
    }

    public void PlaySampleSFX()
    {
        AudioManager.instance.PlaySFX(6);
    }
}
