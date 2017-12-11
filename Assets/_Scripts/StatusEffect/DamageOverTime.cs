using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : TimedStatusEffect
{
    public int damage;

    public override void ApplyEffect()
    {
        playerHealth.TakeDamage(damage);
    }

}
