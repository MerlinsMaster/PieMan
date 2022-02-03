using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDot : MonoBehaviour
{
    public GameObject sound;
    public GameObject effect;

    public float powerDotDuration;
    public int pointValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SM.scoreManager.AddPoints(pointValue);
            //
            SM.levelManager.powerPillTime = powerDotDuration;
            Instantiate(sound, transform.position, transform.rotation);
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
