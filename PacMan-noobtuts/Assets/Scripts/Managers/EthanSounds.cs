using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private int soundIndex;                         // an int to mark which element in the array to use
    private float timeLeft;                         // the current time in the countdown timer
    public float maxTime;                           // the maximum amount of time the countdown timer can set itself to
    public bool playSounds;
    public bool stopSounds;
    public float startDelay;

    private void Awake()
    {
        SM.ethanSounds = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        timeLeft = startDelay;
        //SetTimer();
        //playSounds = true;
    }

    private void Update()
    {
        Timer();
    }

    public void Timer()
    {
        timeLeft -= Time.deltaTime;             // Count down at normal time
        if (timeLeft < 0)                       // if there is no time left
        {
            if (stopSounds)
            {
                return;
            }
            else
            {
                if (playSounds)
                {
                    StartCoroutine(PlayAudioClip());
                }
                SetTimer();                         // reset the timer
            }


        }
    }

    public void SetTimer()
    {
        timeLeft = Random.Range(0, maxTime);    // set a random number between zero and maxTime
    }

    public IEnumerator PlayAudioClip()
    {
        playSounds = false;
        soundIndex = Random.Range(0, audioClips.Length);
        audioSource.PlayOneShot(audioClips[soundIndex]);

        yield return new WaitWhile(() => audioSource.isPlaying);

        //if(!stopSounds)
        playSounds = true;
    }
}
