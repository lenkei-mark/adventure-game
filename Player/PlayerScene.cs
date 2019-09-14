using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScene : MonoBehaviour {

    public int startPoint=-1;
    public bool hasLKey;
    public bool hasRKey;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("LKey"))
        {
            hasLKey = true;
            FindObjectOfType<AudioManager>().Play("Pickup");
        }

        if(other.collider.CompareTag("RKey"))
        {
            hasRKey = true;
            FindObjectOfType<AudioManager>().Play("Pickup");
        }
    }
}
