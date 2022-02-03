using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int numberOfDots;
    public int totalNumberOfDots;

    public float powerPillTime;
    public bool powerPillSoundPlaying;
    public GameObject powerPillSound;

    public float levelIntroDuration;
    public float levelEndDuration;

    public GameObject introSound;
    public GameObject winSound;
    private bool levelEnded;

    public bool ghostsCanMove;

    private SceneLoader sceneLoader;

    private void Awake()
    {
        SM.levelManager = this;
    }

    private void Start()
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();

        SM.scoreManager.score += SM.gameData.currentScore;
        SM.livesManager.lifeCounter = SM.gameData.currentLives;
        levelEnded = false;
        numberOfDots = totalNumberOfDots;
        ghostsCanMove = false;
        LevelIntroCo();
    }

    private void Update()
    {
        if(numberOfDots <= 0 && !levelEnded)
        {
            levelEnded = true;
            LevelEndCo();
        }

        PowerDotUpdate();
    }

    public void SubtractDot()
    {
        numberOfDots--;
    }

    public void LevelIntroCo()
    {
        StartCoroutine(LevelIntro());
    }

    public IEnumerator LevelIntro()
    {
        Instantiate(introSound, transform.position, transform.rotation);


        yield return new WaitForSeconds(levelIntroDuration);

        SM.pacMan.canMove = true;
        ghostsCanMove = true;
    }

    public void LevelEndCo()
    {
        StartCoroutine(LevelEnd());
    }

    public IEnumerator LevelEnd()
    {
        Instantiate(winSound, transform.position, transform.rotation);
        SM.gameData.currentScore = SM.scoreManager.score;


        yield return new WaitForSeconds(levelEndDuration);

        sceneLoader.LoadScene("Game");
    }

    public void PowerDotUpdate()
    {
        if(powerPillTime > 0)
        {
            // start sound effect
            if(!powerPillSoundPlaying)
            {
                powerPillSound.SetActive(true);
                powerPillSoundPlaying = true;
            }
            powerPillTime -= Time.deltaTime;
        }

        if(powerPillTime < 0)
        {
            powerPillTime = 0;
            powerPillSound.SetActive(false);
            powerPillSoundPlaying = false;
        }
    }

    // if game over score = 0
}
