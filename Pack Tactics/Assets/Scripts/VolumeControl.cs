using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource;

    public void SetVolume(float volumeValue)
    {
        audioSource.volume = volumeValue;
    }
}
