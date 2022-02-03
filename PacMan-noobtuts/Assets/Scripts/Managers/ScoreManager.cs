using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;           // the score

    private void Awake()
    {
        SM.scoreManager = this;
    }

    private void Start()
    {
        score = 0;                            // score is set to zero by default
    }

    private void Update()
    {
        if (score < 0)  // This prevents the score from going below zero
            score = 0;
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public void SubtractPoints(int pointsToLose)
    {
        score -= pointsToLose;
    }
}
