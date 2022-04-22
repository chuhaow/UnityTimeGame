// CLASS: Audio
//
// Author: Chu Hao Wen
//
// REMARKS: Holds information for audio clips
//
//-----------------------------------------

using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]

public class Audio
{
    public AudioClip clip;
    [Range(0f,1)]
    public float volume;
    [Range(0f, 1)]
    public float pitch;

    public string name;

    public bool loop;
    public bool PlayOnAwaken;
   
    public AudioSource source;

 


}
