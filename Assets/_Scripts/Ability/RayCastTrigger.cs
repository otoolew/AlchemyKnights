using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTrigger : MonoBehaviour {
    //[HideInInspector]
    public int abilityDamage = 1;                         // Set the number of hitpoints that this gun will take away from shot objects with a health script.
    //[HideInInspector]
    public float abilityRange = 10f;                   // Distance in unity units over which the player can fire.
    //[HideInInspector]
    public float hitForce = 0f;                     // Amount of force which will be added to objects with a rigidbody shot by the player.
    public Transform firePoint;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun.
    //[HideInInspector]
    public LineRenderer laserAbility;                    // Reference to the LineRenderer component which will display our laserline.

    public void Initialize()
    {
        laserAbility = GetComponentInChildren<LineRenderer>();
    }

    public void Fire()
    {
        laserAbility.enabled = true;
        //Declare a raycast hit to store information about what our raycast has hit.
        RaycastHit hit;

        //Start our ShotEffect coroutine to turn our laser line on and off
        //StartCoroutine(ShotEffect());

        //Set the start position for our visual effect for our laser to the position of gunEnd
        laserAbility.SetPosition(0, firePoint.position);
        laserAbility.SetPosition(1, firePoint.transform.forward * abilityRange);
        //Check if our raycast has hit anything
        if (Physics.Raycast(firePoint.position, firePoint.transform.forward, out hit, abilityRange))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
        else
        {
            //if we did not hit anything, set the end of the line to a position directly away from
            laserAbility.SetPosition(1, firePoint.transform.forward * abilityRange);
        }
    }
    private void RepeatFire()
    {
        laserAbility.enabled = true;
        //Declare a raycast hit to store information about what our raycast has hit.
        RaycastHit hit;

        //Start our ShotEffect coroutine to turn our laser line on and off
        //StartCoroutine(ShotEffect());

        //Set the start position for our visual effect for our laser to the position of gunEnd
        laserAbility.SetPosition(0, firePoint.position);
        laserAbility.SetPosition(1, firePoint.transform.forward * abilityRange);
        //Check if our raycast has hit anything
        if (Physics.Raycast(firePoint.position, firePoint.transform.forward, out hit, abilityRange))
        {
            Debug.Log(hit.collider.gameObject.name);
            //Set the end position for our laser line 
            //laserAbility.SetPosition(1, abilityRange);

            //Get a reference to a health script attached to the collider we hit
            //HitBox3D health = hit.collider.GetComponent<HitBox3D>();

            //If there was a health script attached
            //if (health != null)
            //{
            //    //Call the damage function of that script, passing in our gunDamage variable

            //}
        }
        else
        {
            //if we did not hit anything, set the end of the line to a position directly away from
            laserAbility.SetPosition(1, firePoint.transform.forward * abilityRange);
        }
    }
    //private IEnumerator ShotEffect()
    //{

    //    Turn on our line renderer
    //    laserAbility.enabled = true;
    //    Wait for .07 seconds
    //    yield return shotDuration;

    //    Deactivate our line renderer after waiting
    //    laserAbility.enabled = false;
    //}
}
