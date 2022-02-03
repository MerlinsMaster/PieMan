using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] menuPanels;                     // An array of all menu panels
    public GameObject pauseMenu;

    public bool isPaused;

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonUp("Cancel"))
            OnEsc();
    }

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

    public void OnResume()
    {
        for (int i = 0; i < menuPanels.Length; i++)
            menuPanels[i].SetActive(false);
        pauseMenu.SetActive(false);                 // - set pause menu to inactive
        Time.timeScale = 1f;                        // - unpause game
        isPaused = false;
    }

    public void OnEsc()
    {
        if(!isPaused)                                   // if not paused
        {
            AudioManager.instance.PlaySound("clickSound", this.transform);
            Time.timeScale = 0f;                        // - pause game
            pauseMenu.SetActive(true);                  // - set pause menu to active
            isPaused = true;
        }
        else if(isPaused)
        {
            for (int i = 0; i < menuPanels.Length; i++)
                menuPanels[i].SetActive(false);
            AudioManager.instance.PlaySound("clickSound", this.transform);
            pauseMenu.SetActive(false);                 // - set pause menu to inactive
            Time.timeScale = 1f;                        // - unpause game
            isPaused = false;
        }
    }

    public void OnMainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        sceneLoader.LoadScene(sceneName);
    }

    public void OnExit()
    {
        sceneLoader.QuitGame();
    }
}
