using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleStatus : MonoBehaviour {
    public GameObject statusEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Activate()
    {
        statusEffect.SetActive(true);
    }
    public void Deactivate()
    {
        statusEffect.SetActive(false);
    }
}
