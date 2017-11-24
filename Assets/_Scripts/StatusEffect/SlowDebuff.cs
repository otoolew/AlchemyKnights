using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowDebuff : MonoBehaviour {
    public float duration; // when it should expire?
    public float speedReduction;
    public float playerSpeed;
    public bool isActive = false;
    public GameObject particleEffect;
    [HideInInspector]
    public PlayerHealth playerHealth;
    [HideInInspector]
    public NavMeshAgent navAgent;
    // Use this for initialization
    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
        navAgent = GetComponentInParent<NavMeshAgent>();
        playerSpeed = navAgent.speed;
    }

    public void ApplyEffect()
    {
        if (!isActive)
        {
            isActive = true;
            particleEffect.SetActive(true);
            navAgent.speed = speedReduction;
            Invoke("EndEffect", duration);
        }
        else
        {
            Debug.Log("Already Active");
        }

    }
    public void EndEffect()
    {
        CancelInvoke();
        isActive = false;
        navAgent.speed = playerSpeed;
        particleEffect.SetActive(false);
    }
}
