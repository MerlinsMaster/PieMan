using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public string hoverSound;
    public string clickSound;

    public void HoverSound()
    {
        AudioManager.instance.PlaySound(hoverSound, this.transform);
    }

    public void ClickSound()
    {
        AudioManager.instance.PlaySound(clickSound, this.transform);
    }
}
