using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {
    public string abilityName = "New Ability";
    public Sprite abilitySprite;
    public float abilityBaseCoolDown = 1f;
    public abstract void InitializeAbility(GameObject obj);
    public abstract void TriggerAbility();
}
