using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public CanvasGroup faderCanvasGroup;                                    // Canvas that fade UI image is a child of
    public float fadeDuration;                                              // The time it takes for the fade to complete
    private bool isFading;                                                  // Fading happens when this is true

    private void Awake()
    {
        faderCanvasGroup.alpha = 1f;
    }

    private void Start()
    {
        StartCoroutine(Fade(0f));                                           // Fade "in" from black
    }

    public void LoadScene(string sceneName)                                 // CALLED ANY TIME A NEW SCENE NEEDS TO BE LOADED
    {
        StartCoroutine(Transition(sceneName));                              // Call the coroutine Transition
    }

    public IEnumerator Transition(string sceneName)                         // FAEDS OUT AND THEN LOADS THE SPECIFIED SCENE
    {
        yield return StartCoroutine(Fade(1f));                              // Fade "out" to black
        SceneManager.LoadScene(sceneName);                                  // Load the scene
    }

    public IEnumerator Fade(float finalAlpha)                                                                               // FADES "IN" OR "OUT", DEPENDING ON THE FLOAT THAT IS PASSED IN
    {
        isFading = true;                                                                                                    //
        faderCanvasGroup.blocksRaycasts = true;                                                                             // Canvas group is made non-interactable
        float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;                                    // 
        while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))                                                     // 
        {
            faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);     // 
            yield return null;                                                                                              // 
        }
        isFading = false;                                                                                                   // 
        faderCanvasGroup.blocksRaycasts = false;                                                                            // 
    }

    public void QuitGame()
    {
        Application.Quit();                                                 // closes the application
    }
}
