using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalTorch : MonoBehaviour {

    [SerializeField] private GameObject fireEffect;
    [SerializeField] private int torchNumber;
    private PlayerScene player;
	void Start () {
        player = FindObjectOfType<PlayerScene>();
        if (player.hasLKey && torchNumber == 1)
        {
            fireEffect.SetActive(true);
        }
        else if (player.hasRKey && torchNumber == 2)
        {
            fireEffect.SetActive(true);
        }

    }
	
	
	void Update () {
		if(player.hasLKey && torchNumber==1)
        {
            fireEffect.SetActive(true);
        }
        else if(player.hasRKey && torchNumber==2)
        {
            fireEffect.SetActive(true);
        }
	}
}
