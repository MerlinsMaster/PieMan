using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManager : MonoBehaviour
{
    private SceneLoader sceneLoader;

    public float runTime;                                           // set amount of time from beginning of Fade Out to end of scene
    public string sceneToLoad;

    public IEnumerator Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        if(sceneLoader != null)
        {
            yield return StartCoroutine(sceneLoader.Fade(0f));      // Fade "in" from black
            yield return new WaitForSeconds(runTime);               // Hold for set amount of time from beginning of Fade Out to end of scene
            sceneLoader.LoadScene(sceneToLoad);                          // Load the next scene
        }
    }
}
