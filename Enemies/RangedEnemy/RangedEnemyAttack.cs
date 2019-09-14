using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;
    public float timeBtwShoots;
    [SerializeField] private float startTimeBtwShoots;
    [SerializeField] private GameObject shootProjectile;

    private Transform player;
    [SerializeField] Transform wandPos;

    public GameObject projectile;
    

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	
	void Update () {

		if(Vector2.Distance(transform.position, player.position)> stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position)>retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position)<retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        Shoot();
	}

    private void Shoot()
    {
        timeBtwShoots -= Time.deltaTime;
        if (timeBtwShoots<=0.31 && timeBtwShoots>0)
        {
            Instantiate(shootProjectile, new Vector2(wandPos.position.x, wandPos.position.y), Quaternion.identity);
        }
        else if(timeBtwShoots<=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
        }
    }
}
