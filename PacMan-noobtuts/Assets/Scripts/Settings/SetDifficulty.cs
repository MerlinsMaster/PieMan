using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    [SerializeField] private IntVariable difficultySetting;

    public void SetDifficultyLevel(int level)
    {
        difficultySetting.value = level;
    }
}
