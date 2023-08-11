using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Slider masterSlider;

   

    void Start()
    {
        if (PlayerPrefs.GetInt("set default volume") != 1)
        {
            PlayerPrefs.SetInt("set default volume", 1);
            masterSlider.value = .1f;
            PlayerPrefs.SetFloat("master volume", .1f);
        }
        else
        {
            masterSlider.value = PlayerPrefs.GetFloat("master volume");
        }
    }


    void SetVolume(string name, float value)
    {
        float volume = Mathf.Log10(value) * 20;
        if (value == 0)
        {
            volume = -80;
        }

        audioMixer.SetFloat(name, volume);
    }

    public void SetMasterVolume()
    {
        SetVolume("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("master volume", masterSlider.value);

    }

}