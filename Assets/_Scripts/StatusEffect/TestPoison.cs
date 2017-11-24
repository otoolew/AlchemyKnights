using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestPoison : MonoBehaviour {
    public float duration; // when it should expire?
    public float startTime; // should delay the (first) effect tick?
    public float repeatTime; // how much time between each effect tick?
    public int damage;
    public bool isActive = false;
    public GameObject particleEffect;
    [HideInInspector]
    public PlayerHealth playerHealth;
    [HideInInspector]
    public NavMeshAgent navAgent;
    // Use this for initialization
    void Start () {
        
        playerHealth = GetComponentInParent<PlayerHealth>();
        
    }

    public void ApplyEffect()
    {
        if (!isActive)
        {
            isActive = true;
            particleEffect.SetActive(true);
            if (repeatTime > 0)
                InvokeRepeating("DamageEffect", startTime, repeatTime);
            else
                Invoke("DamageEffect", startTime);
            // End the effect accordingly to the duration
            Invoke("EndEffect", duration);
        }
        else
        {
            Debug.Log("Already Active");
        }

    }
    public void DamageEffect()
    {
        playerHealth.TakeDamage(damage);
    }
    public virtual void EndEffect()
    {
        CancelInvoke();
        isActive = false;
        particleEffect.SetActive(false);
    }

}
