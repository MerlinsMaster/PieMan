using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public GameObject sound;
    public GameObject effect;

    public int pointValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SM.scoreManager.AddPoints(pointValue);
            SM.levelManager.SubtractDot();
            Instantiate(sound, transform.position, transform.rotation);
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
