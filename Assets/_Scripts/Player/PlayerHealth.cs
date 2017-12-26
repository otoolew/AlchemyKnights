using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.AI;


public class PlayerHealth : MonoBehaviour {
    private Animator animator;                                          // Reference to the animator.
    private bool damaged;
    private PlayerController playerController;
    private PlayerAbility playerAbility;
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.  

    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    public ParticleSystem healingParticles;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        playerAbility = GetComponent<PlayerAbility>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.D))
        //    TakeDamage(25);
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            // ... it should die.
            Death();
        }
        //CheckToxicInteractions();
        healthSlider.value = currentHealth;

        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        // Reset the damaged flag.
        damaged = false;
    }
    public void TakeDamage(int amount)
    {
        damaged = true;
        //animator.SetTrigger("Damage");
        currentHealth -= amount;
    }
    public void HealDamage(int amount)
    {
        if (currentHealth <= startingHealth)
        {
            if ((currentHealth + amount) > startingHealth)
            {
                currentHealth = startingHealth;
            }
            else
            {
                currentHealth += amount;
                healthSlider.value = currentHealth;
            }
        }
        healingParticles.Play();
    }

    public void Death()
    {
        //Debug.Log("Player Died");
        //playerController.enabled = false;
        playerAbility.enabled = false;
        animator.SetTrigger("Dead");
        GameObject.FindObjectOfType<DeathOptions>().DoDeath();
    }

}
