using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSound : MonoBehaviour {

    private AudioManager audioManager;
    private GameObject player;
    [SerializeField] private float range;

	void Start () {
        audioManager = FindObjectOfType<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void Update () {
        inRange();
	}

    private void inRange()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < range)
        {
            
        }

    }
}
