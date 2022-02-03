using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStatus : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        audioSource.mute = !SM.musicToggle.playMusic;
    }

}
