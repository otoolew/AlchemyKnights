using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : TimedStatusEffect
{

    public int amount;
    protected override void ApplyEffect()
    {
        playerHealth.TakeDamage(amount);
    }
}
