using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastTrigger : MonoBehaviour {
    private ToggleAbility firePoint;                     // Transform variable to hold the location where we will spawn our projectile                        
    private void Start()
    {
        firePoint = GetComponentInChildren<ToggleAbility>();
    }
    public void Activate()
    {
        firePoint.Activate();
    }

    public void Deactivate()
    {
        firePoint.Deactivate();
    }
}
