using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    public bool playMusic;

    private void Awake()
    {
        SM.musicToggle = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            playMusic = !playMusic;
        }
    }
}
