using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);

    }
    public void SetVolumeMute(float volume)
    {
        audioMixer.SetFloat("Volume", 0);

    }
    public void SetVolumeUnMute(float volume)
    {
        audioMixer.SetFloat("Volume", volume);

    }



}
