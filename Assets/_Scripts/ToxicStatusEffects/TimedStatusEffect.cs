﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedStatusEffect : MonoBehaviour {


    public float duration; // when it should expire?
    public float startTime; // should delay the (first) effect tick?
    public float repeatTime; // how much time between each effect tick?
    [HideInInspector]
    public GameObject target;

    void Start()
    {
        // Apply the effect repeated over time or direct?
        if (repeatTime > 0)
            InvokeRepeating("ApplyEffect", startTime, repeatTime);
        else
            Invoke("ApplyEffect", startTime);
        // End the effect accordingly to the duration
        Invoke("EndEffect", duration);
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

