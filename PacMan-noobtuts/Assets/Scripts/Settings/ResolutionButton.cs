using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionButton : MonoBehaviour
{
    public void OnSetResolution(int screenWidth, int screenHeight)
    {
        Screen.SetResolution(screenWidth, screenHeight, Screen.fullScreen);
    }

    public void OnResolutionA()
    {
        OnSetResolution(1366, 768);
    }

    public void OnResolutionB()
    {
        OnSetResolution(1600, 900);
    }

    public void OnResolutionC()
    {
        OnSetResolution(1920, 1080);
    }
}
