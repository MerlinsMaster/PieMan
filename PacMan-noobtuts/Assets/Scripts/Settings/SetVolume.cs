using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;

    public string volumeType;

    public void SetLevel(float volume)
    {
        audioMixer.SetFloat(volumeType, Mathf.Log10(volume) * 20);
    }
}
