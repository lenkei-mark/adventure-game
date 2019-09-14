using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private float speed;
    private int damage;
    private Rigidbody2D rb;
    private float lifeTime = 1f;
    private WeaponFaceMouse arrowStat;

	void Start () {
        arrowStat = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponFaceMouse>();
        speed = arrowStat.arrowSpeed;
        damage = arrowStat.arrowDamage;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed * Time.deltaTime;
    }
	
	void Update () {
        lifeTime -= Time.deltaTime;
        if(lifeTime<=0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.DealDamage(damage);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Rigid"))
        {
            Destroy(gameObject);
        }
    }
}
