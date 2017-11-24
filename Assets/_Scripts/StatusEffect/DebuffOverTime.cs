using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffOverTime : TimedStatusEffect
{
    public override void ApplyEffect()
    {
        navAgent.speed = 3;
    }
    public override void EndEffect()
    {
        navAgent.speed = 5;
        CancelInvoke();
        gameObject.SetActive(false);
    }
}
