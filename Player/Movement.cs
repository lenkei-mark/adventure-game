using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    private Vector2 movement;
    private Rigidbody2D rb;
    private static bool playerExists;

    private float dashSpeed=80f;
    private float dashTime=0.5f;
    [SerializeField] private GameObject dashParticle;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
	}
	
	
	void Update () {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        dashTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTime<=0)
        {
            dashTime = 0.5f;
            Instantiate(dashParticle, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Dash");
            Dash();
        }
        
	}

    void Dash()
    {
        rb.MovePosition(rb.position + movement * dashSpeed * Time.deltaTime);
    }
}
