using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueDestroy : MonoBehaviour
{
    private EdgeCollider2D eColl;
    private BoxCollider2D bColl;
    private BoxCollider2D trigColl;
    [SerializeField] private int type;
    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
        if(type==0)
        {
            eColl = GetComponent<EdgeCollider2D>();
        }
        else
        {
            bColl = GetComponent<BoxCollider2D>();
        }
        trigColl = GetComponent<BoxCollider2D>();
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Sword") || other.CompareTag("Arrow"))
        {
            if(type==0)
            {
                eColl.enabled = false;
            }
            else
            {
                bColl.enabled = false;
            }
            trigColl.enabled = false;
            anim.SetTrigger("Destroy");
            Destroy(gameObject, 0.5f);
        }
    }
}
