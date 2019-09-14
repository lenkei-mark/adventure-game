using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseFighterAttack : MonoBehaviour {

    private bool inRange;
    [SerializeField] private float speed;
    private Transform target;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private int damage = 5;

    private float timeBtwAttacks = 1f;
    private bool canAttack;

    private PlayerHealth playerHealth;
    private EnemyCloseFighter health;
	
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        health = gameObject.GetComponent<EnemyCloseFighter>();
	}
	
	
	void Update ()
    {
        if (isInRange() && health.currentHealth>0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        timeBtwAttacks -= Time.deltaTime;

        if(timeBtwAttacks<=0 && canAttack && health.currentHealth>0)
        {
            timeBtwAttacks = 1f;
            playerHealth.TakeDamage(damage);
        }
	}

    private bool isInRange()
    {
        if(Vector2.Distance(target.transform.position, transform.position)<=distanceToPlayer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            canAttack = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            canAttack = false;
        }
    }
}
