using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject soundContainer;
    public Sound[] sounds;
        
    public void PlaySound(string sound, Transform location)
    {
        for (int i = 0; i < sounds.Length; i++)                                 // find item in array that has the same string variable as "sound"
        {
            if(sounds[i].soundName == sound)
            {
                GameObject s = Instantiate(sounds[i].soundGO, location);        // instantiate the game object in that item
                s.name = "Sound_" + sound;                                      // rename the gameobject
                s.transform.parent = soundContainer.transform;                  // parent the gameobject to the empty where all the sounds will be grouped
            }
        }
    }

    
}
