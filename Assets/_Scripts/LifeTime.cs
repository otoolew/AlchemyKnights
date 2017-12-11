using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {
    public float secondsToLive;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2f);
	}
}
