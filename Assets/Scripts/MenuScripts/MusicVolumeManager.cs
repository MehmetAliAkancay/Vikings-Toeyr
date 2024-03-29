using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MusicVolumeManager : MonoBehaviour
{
    public AudioSource music;
    public Slider slider;
    public TextMeshProUGUI musicAmount;
    private void Awake()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void MusicSys()
    {
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
        music.volume = slider.value;
        musicAmount.text = (slider.value * 100).ToString();
        double numara = Convert.ToDouble(musicAmount.text);
        if (numara < 10)
        {
            musicAmount.text = musicAmount.text[0] + "";
        }
        else if (numara == 100)
        {
            musicAmount.text = "100";
        }
        else
        {
            musicAmount.text = musicAmount.text[0] + "" + musicAmount.text[1];
        }
    }
}
