// CLASS: AudioManagers
//
// Author: Chu Hao Wen
//
//-----------------------------------------
using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.Audio;
public class AudioManager : MonoBehaviour
{
    public Audio[] sounds;
    public AudioSource[] audioSource;
    public AudioMixer audioMixer;
    public AudioMixerGroup audioMixerGroup;
    #region Singleton
    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        foreach (Audio a in sounds)
        {
            
            a.source = this.gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.volume;
           a.source.pitch = a.pitch;
            a.source.loop = a.loop;
            a.source.playOnAwake = a.PlayOnAwaken;
            a.source.outputAudioMixerGroup = audioMixerGroup ;
          
        }
        audioSource = gameObject.GetComponents<AudioSource>();
    }
    #endregion

    //------------------------------------------------------
    // SetVolume
    //
    // PURPOSE:    Change all volume and pitch levels of all audio clips 
    //             to the one specified
    // PARAMETERS:
    //     volume - the desired volume
    //------------------------------------------------------
    public void SetVolume(float volume)
    {
        Debug.Log("A" + volume);
        foreach(AudioSource a in audioSource)
        {
            a.volume = volume;
            a.pitch = volume;
            
        }
    }

    //------------------------------------------------------
    // PlaySound
    //
    // PURPOSE:    Play the sound of the audio clip
    // PARAMETERS:
    //     name - name of audio clip
    //------------------------------------------------------
    public void PlaySound(string name)
    {

        Audio a = Array.Find(sounds, item => item.name == name);
        if (a == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        a.source.volume = a.volume; //Set Volume and pitch to what is specifyed
        a.source.pitch = a.pitch;

        a.source.Play(0);
    }

    //------------------------------------------------------
    // StopSound
    //
    // PURPOSE:    Stop the sound of the audio clip
    // PARAMETERS:
    //     name - name of audio clip
    //------------------------------------------------------
    public void StopSound(string name)
    {
        Audio a = Array.Find(sounds, item => item.name == name);    // Find Audio Clip
        if (a == null)  //If it can't be found
        {
            Debug.LogWarning("Sound: " + name + " not found!"); 
            return;
        }
      

        a.source.Stop();    
    }

    //------------------------------------------------------
    // Play
    //
    // PURPOSE:    Add new audioclip 
    // PARAMETERS:
    //     clip - the clip object to be added
    //------------------------------------------------------
    public void Play(AudioClip clip)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
