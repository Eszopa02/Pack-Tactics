using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    //public AudioSource audioSource;
    public List<AudioSource> musicAudio;
    public List<AudioSource> sfxAudio;



    //public void SetVolume(float newVolume)
    //{
    //audioSource.volume = volumeValue;

    //musicAudio.volume = Mathf.Clamp01(newVolume);
    //sfxAudio.volume = Mathf.Clamp01(newVolume);
    //}

    [Range(0f, 1f)]
    public float targetVolume;

    public void SetAllMusicVolume()
    {
        if (musicAudio == null || musicAudio.Count == 0)
        {
            return;
        }

        foreach (AudioSource audioSource in musicAudio)
        {
            if (audioSource != null)
            {
                audioSource.volume = targetVolume;
            }
        }
    }

    public void SetAllSFXVolume()
    {
        if (sfxAudio == null || sfxAudio.Count == 0)
        {
            return;
        }

        foreach (AudioSource audioSource in sfxAudio)
        {
            if (audioSource != null)
            {
                audioSource.volume = targetVolume;
            }
        }
    }

    void Start()
    {
        SetAllMusicVolume();
        SetAllSFXVolume();

    }

    public void UpdateTargetMusicVolume(float newVolume)
    {
        targetVolume = Mathf.Clamp01(newVolume);
        
        SetAllMusicVolume();
    }

    public void UpdateTargetSFXVolume(float newVolume)
    {
        targetVolume = Mathf.Clamp01(newVolume);
        SetAllSFXVolume();
        
    }
}
