using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDisappear : MonoBehaviour {

    private PlayerScene playerScene;
    [SerializeField]private string keyName;

    void Start()
    {
        playerScene = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScene>();
        if(playerScene.hasLKey && keyName=="LKey")
        {
            Destroy(gameObject);
        }
        else if(playerScene.hasRKey && keyName=="RKey")
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
