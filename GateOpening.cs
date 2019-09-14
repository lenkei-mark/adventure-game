using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpening : MonoBehaviour {

    private PlayerScene player;
	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScene>();
	}
	
	
	void Update () {
		if(player.hasLKey && player.hasRKey)
        {
            Destroy(gameObject, 3f);
        }
	}
}
