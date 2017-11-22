using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.AI;


public class PlayerHealth : MonoBehaviour {
    private Animator animator;                                          // Reference to the animator.

    private bool isDead;
    private bool damaged;
    private bool isSinking;
    private bool poisoned;
    private bool blind;
    private bool healing;
    public ToxicManager toxicManager;
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt. 
    public Image blindImage;                                    // Reference to an image to blind player.   

    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public float sinkSpeed = 0.1f;                              // The speed at which the enemy sinks through the floor when dead.  

    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;
    //AudioSource enemyAudio;                                   // Reference to the audio source.
    //ParticleSystem hitParticles;                              // Reference to the particle system that plays when the enemy is damaged.
    public ParticleSystem poisonParticles;
    public ParticleSystem healingParticles;
    public Transform dropPoint;
    public GameObject emptyPotionPrefabs;

    public DiscoLights dizzy;
    private float poisonTimer;
    private float tickTimer;
    public UnityEvent OnDeath;

    void Awake()
    {
        // Setting up the references.
        animator = GetComponentInParent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        //hitParticles = GetComponentInChildren<ParticleSystem>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }
    void Start()
    {
        CureBlind();
        poisoned = false;
        blind = false;
    }

    void Update()
    {
        poisonTimer += Time.deltaTime;
        tickTimer += Time.deltaTime;

        CheckToxicInteractions();
        healthSlider.value = currentHealth;

        // DEBUG Status Effects
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Blind");
            ApplyBlind();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Poison");
            ApplyPoison();
        }
        // END DEBUG Status Effects
        if (poisoned && poisonTimer < 5f)
            Poison();
        else
        {
            poisoned = false;
            poisonTimer = 0;
        }

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

        if (isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakePotion(int slot)
    {
        switch (slot)
        {
            case 0:
                Debug.Log("Took Red Potion");
                toxicManager.UpdateSlider(slot);
                HealDamage(50);
                break;
            case 1:
                Debug.Log("Took Blue Potion");
                toxicManager.UpdateSlider(slot);
                CureBlind();
                break;
            case 2:
                Debug.Log("Took Green Potion");
                CurePoison();
                toxicManager.UpdateSlider(slot);
                break;
            case 3:
                Debug.Log("Took Yellow Potion");
                DisableDizzy();
                toxicManager.UpdateSlider(slot);
                DisableDizzy();
                break;
            default:
                break;
        }
        //GameObject emptyPotionClone = Instantiate(emptyPotionPrefabs, dropPoint.position, Quaternion.identity);
    }

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Trigger Damage Animation
        animator.SetTrigger("Damage");
        currentHealth -= amount;
        healthSlider.value -= amount;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }
    public void ApplyBlind()
    {
        blind = true;
        blindImage.CrossFadeAlpha(1f, .1f, false);
    }
    public void CureBlind()
    {
        blindImage.CrossFadeAlpha(0.1f, 2.0f, false);
    }
    public void ApplyPoison()
    {
        poisoned = true;
        poisonParticles.Play();
    }
    public void ApplyDizzy()
    {
        TakeDamage(10);
        dizzy.isActive = true;
    }
    public void DisableDizzy()
    {
        dizzy.isActive = false;
    }
    private void Poison()
    {
        if (tickTimer > 1)
        {
            // Reduce the current health by the damage amount.
            currentHealth -= 1;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;
            tickTimer = 0;
        }

        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }
    public void CurePoison()
    {
        poisoned = false;
        if (poisonParticles.isPlaying)
            poisonParticles.Stop();
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
                // Increase the current health by the healing amount.
                currentHealth += amount;

                // Set the health bar's value to the current health.
                healthSlider.value = currentHealth;
            }
        }
        healingParticles.Play();
    }
    // Can be implemented better but its like 2:38 AM
    public void CheckToxicInteractions()
    {
        // Red Toxic Check
        if (toxicManager.toxicSliders[0].value > 50)
        {
            GetComponent<NavMeshAgent>().speed = 3;
        }
        else
        {
            GetComponent<NavMeshAgent>().speed = 5;
        }
        // Blue Toxic Check
        if (toxicManager.toxicSliders[1].value > 95)
        {
            if (!dizzy.isActive)
                ApplyDizzy();
            //Debug.Log("Dizzy not implemented. Apply Dizzy Here");
        }
        // Green Toxic Check
        if (toxicManager.toxicSliders[2].value > 75)
        {
            if (!blind)
                ApplyBlind();
        }
        // Yellow Toxic Check
        if (toxicManager.toxicSliders[3].value > 75)
        {
            if (!poisoned)
                ApplyPoison();
        }

    }
    public void PerminentDamage(int amount)
    {

    }

    public void Death()
    {
        isDead = true;
        animator.SetTrigger("Die");

        StartSinking();
        // The enemy is dead.



        // Tell the animator that the enemy is dead.
        //animator.SetTrigger("Die");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
        OnDeath.Invoke();
    }

    public void StartSinking()
    {
        // Find and disable the Nav Mesh Agent.
        GetComponent<NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;
        // Increase the score by the enemy's score value.
        StartCoroutine(DisableObject());

    }
    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
