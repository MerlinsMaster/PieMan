using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieManSoundbites : MonoBehaviour
{
    public GameObject[] soundbites;                 // Array of sound gameobjects
    private int soundIndex;                         // an int to mark which element in the array to use
    private float timeLeft;                         // the current time in the countdown timer
    public float maxTime;                           // the maximum amount of time the countdown timer can set itself to

    private void Awake()
    {
        //SM.cecilSounds = this;
    }

    private void Start()
    {
        SetTimer();
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
            PlaySoundbite();                    // play a sound
            SetTimer();                         // reset the timer
        }
    }

    public void SetTimer()
    {
        timeLeft = Random.Range(0, maxTime);    // set a random number between zero and maxTime
    }

    public void PlaySoundbite()
    {
        soundIndex = Random.Range(0, soundbites.Length);                                    // set the soundIndex to a random number between zero and the number of elements in the array
        Instantiate(soundbites[soundIndex], transform.position, Quaternion.identity);       // instantiate the element in the array specified by that index
    }
}
