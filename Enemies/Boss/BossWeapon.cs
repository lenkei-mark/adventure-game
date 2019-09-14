using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour {

    private PlayerHealth player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.TakeDamage((int)player.startHealth);
        }
    }
}
