using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/BlastAbility")]
public class BlastAbility : Ability {

    private BlastTrigger launcher;

    public override void InitializeAbility(GameObject obj)
    {
        launcher = obj.GetComponent<BlastTrigger>();

        abilityType = AbilityType.RayCast;
    }
    public override void TriggerAbility()
    {
        launcher.Activate();
    }
    public override void DeactivateAbility()
    {
        launcher.Deactivate();
    }
}
