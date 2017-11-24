using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowStatusEffect : MonoBehaviour {

    public float effectsDisplayTime = 3f;
    float timer = 0;
    public ParticleSystem effectParticles;
    private NavMeshAgent navAgent;
    public bool isActive;
    private void Awake()
    {
        navAgent = GetComponentInParent<NavMeshAgent>();
        effectParticles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (isActive)
        //{
        //    if (timer >= effectsDisplayTime && Time.timeScale != 0)
        //    {
        //        //DisableEffects();
        //    }
        //}      
    }

    public void EnableEffects()
    {
        isActive = true;
        timer = 0f;
        navAgent.speed = 3;
        effectParticles.Stop();
        effectParticles.Play();
    }
    public void DisableEffects()
    {
        isActive = false;
        timer = 0f;
        navAgent.speed = 5;
        effectParticles.Stop();
    }
}
