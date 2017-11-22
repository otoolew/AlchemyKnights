using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedStatusEffect : MonoBehaviour {

    public float duration; // when it should expire?
    public float startTime; // should delay the (first) effect tick?
    public float repeatTime; // how much time between each effect tick?
    public string curedBy;
    [HideInInspector]
    public PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        // Apply the effect repeated over time or direct?

    }

    protected virtual void ApplyEffect()
    {
    }
    protected virtual void EndEffect()
    {
        CancelInvoke();
        Destroy(gameObject);
    }
}
