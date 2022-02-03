using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    private VideoPlayer vplayer;

    private void Awake()
    {
        vplayer = GetComponent<VideoPlayer>();
        vplayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "intro.mp4");
    }

    private void Start()
    {
        //vplayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "intro.mp4");

        vplayer.Play();
    }
}
