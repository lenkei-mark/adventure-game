using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnTime=6f;
	void Start () {
        InvokeRepeating("Spawn", 3f, spawnTime);
	}
	
    void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
