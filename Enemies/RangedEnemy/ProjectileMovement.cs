using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

    [SerializeField] private float speed;
    private Transform player;
    private Vector2 target;
    private Rigidbody2D rb;
    [SerializeField] private GameObject destroyParticle;
    [SerializeField] private int damage;

    private PlayerHealth playerHealth;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
        target = new Vector2(player.position.x, player.position.y);
        transform.up = target - new Vector2(transform.position.x, transform.position.y);
        
	}
	
	// Update is called once per frame
	void Update () {
        if(new Vector2(transform.position.x, transform.position.y)==target)
        {
            Instantiate(destroyParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
    
}
