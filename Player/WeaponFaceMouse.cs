using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFaceMouse : MonoBehaviour {

    [SerializeField] private GameObject bow;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float maxBowtime = 1f;
    public float arrowSpeed;
    public int arrowDamage;
    [SerializeField] private float timeBtwShoots=1f;
	
	void Start () {
		
	}
	
	
	void Update () {
        faceMouse();
        changeWeapons();
        shootBow();
	}

    private void faceMouse()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }

    private void changeWeapons()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            sword.SetActive(true);
            bow.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            sword.SetActive(false);
            bow.SetActive(true);
        }
    }
    void shootBow()
    {
        if (timeBtwShoots <= 0)
        {
            if (bow.activeInHierarchy && Input.GetMouseButton(0))
            {
                maxBowtime -= Time.deltaTime;
            }
            if (bow.activeInHierarchy && Input.GetMouseButtonUp(0))
            {
                if (maxBowtime <= 0)
                {
                    arrowSpeed = 400f;
                    arrowDamage = 100;
                    Instantiate(arrow, shootPoint.position, transform.rotation);
                    maxBowtime = 1f;
                    timeBtwShoots = 0.5f;
                }
                else if (maxBowtime > 0 && maxBowtime <= 0.5)
                {
                    arrowSpeed = 300f;
                    arrowDamage = 50;
                    Instantiate(arrow, shootPoint.position, transform.rotation);
                    maxBowtime = 1f;
                    timeBtwShoots = 0.75f;
                }
                else if (maxBowtime > 0.5)
                {
                    arrowSpeed = 200f;
                    arrowDamage = 25;
                    Instantiate(arrow, shootPoint.position, transform.rotation);
                    maxBowtime = 1f;
                    timeBtwShoots = 1f;
                }
                FindObjectOfType<AudioManager>().Play("BowShoot");
            }
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
