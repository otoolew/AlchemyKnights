using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/MeleeAbility")]
public class MeleeAbility : Ability
{
    public int abilityDamage = 1;
    public float abilityRange = 50f;
    public float hitForce = 10f;
    public Color laserColor = Color.white;

    private MeleeTrigger meleeTrigger;

    public override void InitializeAbility(GameObject obj)
    {
        meleeTrigger = obj.GetComponent<MeleeTrigger>();
        meleeTrigger.Initialize();
        meleeTrigger.abilityDamage = abilityDamage;
    }

    public override void TriggerAbility()
    {
        Debug.Log("Swing");
        meleeTrigger.Swing();
    }
}
