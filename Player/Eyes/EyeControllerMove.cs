using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeControllerMove : MonoBehaviour {

	[SerializeField] private float eyeSpeed;
    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(mousePos);
	}
}
