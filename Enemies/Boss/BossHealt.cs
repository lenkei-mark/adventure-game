using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealt : MonoBehaviour, IDamageable {

    [SerializeField] private int startHealth;
    public int currentHealth;
    private float lastTakenDamage = 0;
    [SerializeField] private Animator anim;
    public GameObject bloodParticle;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color maxHealth;
    [SerializeField] private Color zeroHealthColor;
    private AudioManager audioManager;
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField] private GameObject WinScreen;

    void Start () {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
        healthBarSlider.value = currentHealth;
        healthBar.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }
	
	
	void Update () {
        lastTakenDamage -= Time.deltaTime;
        healthBarSlider.value = currentHealth;
        fillImage.color = Color.Lerp(maxHealth, zeroHealthColor, currentHealth);
    }

    public void DealDamage(int damage)
    {
        healthBar.SetActive(true);
        if (lastTakenDamage <= 0 && currentHealth > 0)
        {
            currentHealth -= damage;
            lastTakenDamage = 0.2f;
            anim.SetBool("isHit", true);
            audioManager.Play("Hit");
            Invoke("isHitFalse", 0.2f);
            CheckIfDead();
        }
    }

    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            rb.isKinematic = false;
            coll.enabled = false;
            Instantiate(bloodParticle, transform.position, Quaternion.identity);
            anim.SetTrigger("isDead");
            WinScreen.SetActive(true);
            Destroy(gameObject, 1f);
        }
    }

    private void isHitFalse()
    {
        anim.SetBool("isHit", false);
    }
}
