using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class TimeStopVFX : MonoBehaviour
{
    public LensDistortion lensDistortion;
    public PostProcessVolume postProcessCam;
    public float timer;
    public ColorGrading colorGrading;
    public TimeManager t;
    public static float MAX_DISTORTION = 100;
    public static float MAX_HUE_SHIFT = 180;
    public bool hasPlayedStopVFX = false;


    private void Start()
    {
        t = TimeManager.instance;
        postProcessCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessVolume>();
        lensDistortion = postProcessCam.profile.GetSetting<LensDistortion>();
        colorGrading = postProcessCam.profile.GetSetting<ColorGrading>();
    }
    // Update is called once per frame
    void Update()
    {
        if (t.IsTimeStopping&&!hasPlayedStopVFX )
        {
           StartVFX();
        }
        else if (!t.IsTimeStopping&&hasPlayedStopVFX)
        {

            EndVFX();
        }

    }

    public void EndVFX()
    {
        timer += Time.deltaTime;
        if (timer < (t.EndAudioDuration / 2))
        {
            colorGrading.hueShift.value += (MAX_HUE_SHIFT / (t.EndAudioDuration / 2)) * Time.deltaTime;
            lensDistortion.intensity.value -= (MAX_DISTORTION / (t.EndAudioDuration / 2)) * Time.deltaTime;
        }
        else
        {
            colorGrading.hueShift.value -= (MAX_HUE_SHIFT / (t.EndAudioDuration / 2)) * Time.deltaTime;
            lensDistortion.intensity.value += (MAX_DISTORTION / (t.EndAudioDuration / 2)) * Time.deltaTime;
            if (lensDistortion.intensity.value >= 0)
            {
                colorGrading.hueShift.value = 0;
                lensDistortion.intensity.value = 0;
                colorGrading.saturation.value = 0;
                hasPlayedStopVFX = false;
                timer = 0;
                return;
               
            }
        }
    }
    public void StartVFX()
    {
       
            timer += Time.deltaTime;
            if (timer < (t.StartAudioDuration / 2))
            {
                colorGrading.hueShift.value += (MAX_HUE_SHIFT / (t.StartAudioDuration / 2)) * Time.deltaTime;
                lensDistortion.intensity.value += (MAX_DISTORTION / (t.StartAudioDuration / 2)) * Time.deltaTime;
            }
            else
            {
                colorGrading.hueShift.value -= (MAX_HUE_SHIFT / (t.StartAudioDuration / 2)) * Time.deltaTime;
                lensDistortion.intensity.value -= (MAX_DISTORTION / (t.StartAudioDuration / 2)) * Time.deltaTime;
                if (lensDistortion.intensity.value <= 0)
                {
                    colorGrading.hueShift.value = 0;
                    lensDistortion.intensity.value = 0;
                    colorGrading.saturation.value = -100;
                    hasPlayedStopVFX = true;
                    timer = 0;
                    return;
                }
            }
        
        
    }
    public void Distortion()
    {

        timer += Time.deltaTime;
        if (timer < 1.1f)
        {

            lensDistortion.intensity.value += (100f / 1.1f) * Time.deltaTime;
        }
        else
        {
            lensDistortion.intensity.value -= (100f / 1.1f) * Time.deltaTime;
            if (lensDistortion.intensity.value <= 0)
            {
                lensDistortion.intensity.value = 0;


                return;
            }
        }


    }
}
