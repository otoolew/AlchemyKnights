﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability {
    public float projectileForce = 250;
    public Rigidbody projectile;
    private ProjectileTrigger launcher;

    public override void DeactivateAbility()
    {
        throw new System.NotImplementedException();
    }

    public override void InitializeAbility(GameObject obj)
    {
        launcher = obj.GetComponent<ProjectileTrigger>();
        launcher.projectileForce = projectileForce;
        launcher.projectile = projectile;
        abilityType = AbilityType.Projectile;
    }

    public override void TriggerAbility()
    {
        launcher.Launch();
    }
}
