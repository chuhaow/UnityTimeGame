using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public AudioManager AM;
  
    public float duration;
    public bool IsTimeStopped;
    public bool IsTimeStopping = false;
    public float StartAudioDuration;
    public float EndAudioDuration;
    #region Singleton
    public static TimeManager instance;
    //public TimestopVFXController VFX;
   
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
        
    }
    #endregion
    private void Start()
    {
   
        AM = AudioManager.instance;
    }
    public void ZaWarudo()
    {

        IsTimeStopping = true;
        AM.PlaySound("Time Stop SFX");
        StartCoroutine(WaitForSoundTimeStop());
     
        
    }

    public void TimeResume()
    {
        IsTimeStopping= false ;
        AM.PlaySound("Time Resume SFX");
        StartCoroutine(WaitForSoundTimeResume());
    }

    IEnumerator WaitForSoundTimeStop()
    {
       
        yield return new WaitForSecondsRealtime(StartAudioDuration);
        IsTimeStopped = true;

    }
    IEnumerator WaitForSoundTimeResume()
    {
        yield return new WaitForSecondsRealtime(EndAudioDuration);
        IsTimeStopped = false;

    }
}
