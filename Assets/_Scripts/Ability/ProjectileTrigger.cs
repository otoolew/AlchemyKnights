using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour {

    [HideInInspector]
    public Rigidbody projectile;                          // Rigidbody variable to hold a reference to our projectile prefab
    public Transform firePoint;                           // Transform variable to hold the location where we will spawn our projectile
    [HideInInspector]
    public float projectileForce;                  // Float variable to hold the amount of force which we will apply to launch our projectiles

    public void Launch()
    {
        //Instantiate a copy of our projectile and store it in a new rigidbody variable called clonedBullet
        Rigidbody clonedProjectile = Instantiate(projectile, firePoint.position, transform.rotation) as Rigidbody;
        clonedProjectile.AddForce(firePoint.transform.forward * projectileForce);
    }
}
