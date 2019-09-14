using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour {

    private int damage = 30;
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable!=null)
        {
            damageable.DealDamage(damage);
        }
    }
}
