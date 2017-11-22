using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public string statusEffectName = "StatusEffect";
    public abstract void InitializeStatusEffect(GameObject obj);
    public abstract void ApplyStatusEffect();
    public abstract void RemoveStatusEffect();
}
