using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFX : MonoBehaviour {

    public ParticleSystem particleEffect;

    public void OnEnable()
    {
        particleEffect.Play();
    }

}
