using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/RaycastAbility")]
public class RayCastAbility : Ability
{
    public int abilityDamage = 1;
    public float abilityRange = 50f;
    public float hitForce = 0f;
    //public Color laserColor = Color.white;

    private RayCastTrigger rcShoot;

    public override void InitializeAbility(GameObject obj)
    {
        rcShoot = obj.GetComponent<RayCastTrigger>();
        rcShoot.Initialize();

        rcShoot.abilityDamage = abilityDamage;
        rcShoot.abilityRange = abilityRange;
        rcShoot.hitForce = hitForce;
        
        //rcShoot.laserAbility.material = new Material(Shader.Find("Unlit/Color"))
        //{
        //    color = laserColor
        //};
    }

    public override void TriggerAbility()
    {
        rcShoot.InvokeRepeating("Fire",0.0f,0.3f);
    }
}
