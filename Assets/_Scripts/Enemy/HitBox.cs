using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {
    public List<string> collisionTags;
    private void OnTriggerEnter(Collider otherCollider)
    {
        for (int i = 0; i < collisionTags.Count; i++)
        {
            if (otherCollider.gameObject.tag == collisionTags[i])
            {
                Debug.Log("Player Hit!");
            }
        }     
    }
}
