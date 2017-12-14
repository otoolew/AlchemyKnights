using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AbilityType { Projectile, RayCast};
public abstract class Ability : ScriptableObject {
    public string abilityName = "New Ability";
    public Sprite abilitySprite;
    public float abilityBaseCoolDown = 1f;
    public AbilityType abilityType;
    public abstract void InitializeAbility(GameObject obj);
    public abstract void TriggerAbility();
    public abstract void DeactivateAbility();
}
