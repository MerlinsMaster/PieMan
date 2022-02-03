using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public GameObject[] lifeGraphic;

    private void Awake()
    {
        SM.livesDisplay = this;
    }

    private void Start()
    {
        UpdateLives();
    }

    public void UpdateLives()
    {
        for (int i = 0; i < lifeGraphic.Length; i++)
        {
            if ((SM.livesManager.lifeCounter - 1) >= i)
            {
                lifeGraphic[i].SetActive(true);
            }
            else
            {
                lifeGraphic[i].SetActive(false);
            }
        }
    }

    
    
}
