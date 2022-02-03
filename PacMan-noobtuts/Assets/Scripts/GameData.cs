using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public int currentScore;
    public int currentLives;

    private void Awake()
    {
        SM.gameData = this;
    }
}
