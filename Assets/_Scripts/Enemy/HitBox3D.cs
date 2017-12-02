using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBox3D : MonoBehaviour {

    public List<string> collidesWithTags = new List<string>();
    public CapsuleCollider capsuleCollider;

    void OnTriggerEnter(Collider col)
    {
        for (int i = 0; i < collidesWithTags.Count; i++)
        {
            if (col.gameObject.tag == collidesWithTags[i])
            {
                col.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
            }
        }     
    }
}
