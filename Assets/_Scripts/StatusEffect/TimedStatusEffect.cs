using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TimedStatusEffect : MonoBehaviour {
    public float duration; // when it should expire?
    public float startTime; // should delay the (first) effect tick?
    public float repeatTime; // how much time between each effect tick?
    [HideInInspector]
    public PlayerHealth playerHealth;
    [HideInInspector]
    public NavMeshAgent navAgent;
    void OnEnable()
    {
        navAgent = GetComponentInParent<NavMeshAgent>();
        playerHealth = GetComponentInParent<PlayerHealth>();
        // Apply the effect repeated over time or direct?
        if (repeatTime > 0)
            InvokeRepeating("ApplyEffect", startTime, repeatTime);
        else
            Invoke("ApplyEffect", startTime);
        // End the effect accordingly to the duration
        Invoke("EndEffect", duration);
    }

    public virtual void ApplyEffect()
    {
    }

    public virtual void EndEffect()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
}

