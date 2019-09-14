using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float startHealth=100f;
    private float currentHealth;

    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color maxHealth;
    [SerializeField] private Color minHealth;

    [SerializeField] private Image damageImage;
    private float flashSpeed = 5f;
    private Color flashColour = new Color(255f, 0f, 0f, 0.5f);
    private bool damaged;
    private AudioManager audioManager;

    private PlayerScene scene;

    void Start () {
        audioManager = FindObjectOfType<AudioManager>();
        currentHealth = startHealth;
        healthBarSlider.value = currentHealth;
        scene = FindObjectOfType<PlayerScene>();
	}
	
	
	void Update () {
        fillImage.color = Color.Lerp(maxHealth, minHealth, (float)(currentHealth / 100));
        Flash();
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        audioManager.Play("PlayerHit");
        healthBarSlider.value = currentHealth;
        damaged = true;   
        if(currentHealth<0)
        {
            Death();
        }
    }

    private void Flash()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    void Death()
    {
        scene.startPoint = 1;
        SceneManager.LoadScene(0);
        currentHealth = startHealth;
        healthBarSlider.value = currentHealth;
    }
}
