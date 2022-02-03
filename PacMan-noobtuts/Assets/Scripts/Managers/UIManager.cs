using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreAmount;

    private void Start()
    {
        DisplayUI();
    }

    private void Update()
    {
        DisplayUI();
    }

    void DisplayUI()
    {
        scoreAmount.text = SM.scoreManager.score.ToString("000");
    }
}
