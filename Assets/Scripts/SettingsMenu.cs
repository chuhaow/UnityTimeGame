using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float playerVolume;
    public Slider slider;
    void Awake()
    {
        playerVolume = PlayerPrefs.GetFloat("PVolume");
        slider.value = playerVolume;
        Debug.Log(playerVolume);
        Debug.Log(PlayerPrefs.HasKey("PVolume"));
    }
    public void Start()
    {
        
    }
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("PVolume", volume);
        audioMixer.SetFloat("Volume", volume);
    }

    
}
