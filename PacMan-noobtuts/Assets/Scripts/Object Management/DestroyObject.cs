using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float duration;

    private void Start()
    {
        Destroy(gameObject, duration);
    }
}
