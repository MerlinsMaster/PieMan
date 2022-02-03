using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject[] menuPanels;                     // An array of all menu panels

    public void SelectPanel(int panelNumber)
    {
        for (int i = 0; i < menuPanels.Length; i++)     // For each item in menuPanels
        {
            if (panelNumber == i)                       // If the panelNumber passed in matches the item's index...
            {
                menuPanels[i].SetActive(true);          // ...then set it as active
            }
            else
            {
                menuPanels[i].SetActive(false);         // ...if not, set it as inactive
            }
        }
    }
}
