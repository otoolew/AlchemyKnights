using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    public float timeBetweenTick = 0.15f;
    public float effectsDisplayTime = 5f;
    float timer = 0;
    public ParticleSystem effectParticles;
    private bool isActive;
    private PlayerHealth playerHealth;
    private void Awake()
    {
        effectParticles = GetComponent<ParticleSystem>();
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Poison");
            EnableEffects();
        }
        Debug.Log(isActive);
        if (isActive && timer >= timeBetweenTick && Time.timeScale !=0)
        {
            if (isActive)
            {
                
                Debug.Log("Tick");
                TickEffect();
            }
        }
        //// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        //if (timer >= timeBetweenTick * effectsDisplayTime)
        //{
        //    // ... disable the effects.
        //    DisableEffects();
        //}
    }
    private void TickEffect()
    {
        playerHealth.TakeDamage(5);
        timer = 0f;
    }
    public void EnableEffects()
    {
        isActive = true;
        // Reset the timer.
        timer = 0f;
        // Stop the particles from playing if they were, then start the particles.
        effectParticles.Stop();
        Debug.Log("Play");
        effectParticles.Play();
    }
    public void DisableEffects()
    {
        isActive = false;
        effectParticles.Stop();
    }
}
