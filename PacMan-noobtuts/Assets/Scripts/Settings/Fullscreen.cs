using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    public bool isFullscreen;
    public Text onOff;

    public void SetFullscreen()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
            onOff.text = ("On");
        else
            onOff.text = ("Off");
    }
}
