using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject[] settingsPanels;                     // An array of all settings panels

    public void SelectPanel(int panelNumber)
    {
        for (int i = 0; i < settingsPanels.Length; i++)     // For each item in settingsPanels
        {
            if (panelNumber == i)                           // If the panelNumber passed in matches the item's index...
            {
                settingsPanels[i].SetActive(true);          // ...then set it as active
            }
            else
            {
                settingsPanels[i].SetActive(false);         // ...if not, set it as inactive
            }
        }
    }
}
