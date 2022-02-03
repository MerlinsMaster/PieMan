using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumePing : MonoBehaviour
{
    public AudioClip clip;
    public Slider slider;

    public void Ping()
    {
        AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, 0), slider.value);
    }
}
