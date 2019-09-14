using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {

    private float timeBtwShoots;
    [SerializeField] private float startTimeBtwShoots;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;
    [SerializeField] private GameObject shootProjectile;
    [SerializeField] private GameObject weaponHandler;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int dmg;
    [SerializeField] private Transform wandPos;
    private PlayerHealth playerHealth;

    private int random;

    private Transform player;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        timeBtwShoots = startTimeBtwShoots;
	}
	
	
	void Update () {
        CloseQuartersCombat();
        RangedCombat();
    }

    void CloseQuartersCombat()
    {
        weaponHandler.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        if(Vector2.Distance(gameObject.transform.position, player.position)>1)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        
    }

    void RangedCombat()
    {
        timeBtwShoots -= Time.deltaTime;
        if (timeBtwShoots <= 0)
        {
            Instantiate(shootProjectile, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            playerHealth.TakeDamage(dmg);
        }
    }
}
