using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAbility : MonoBehaviour {
    public GameObject abilityPrefab;                          // Rigidbody variable to hold a reference to our projectile prefab                       
                                                              // Use this for initialization
    void Start () {
       // abilityPrefab = GetComponentInChildren<ParticleSystem>().gameObject;
    }
	public void Activate()
    {
        abilityPrefab.SetActive(true);
    }
    public void Deactivate()
    {
        abilityPrefab.SetActive(false);
    }
}
