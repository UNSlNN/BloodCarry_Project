using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SaveMixer", 70));
    }
    public void SetVolume(float value)
    {
        if(value < 1)
        {
            value = .001f;
        }
        RefreshSilder(value);
        PlayerPrefs.SetFloat("SaveMixer", value);
        masterMixer.SetFloat("Mixer", Mathf.Log10(value / 100) * 20f);
    }
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }
    public void RefreshSilder(float _value)
    {
        soundSlider.value = _value;
    }
}
