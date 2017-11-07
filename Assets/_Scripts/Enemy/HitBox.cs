using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {
    public int hitDamage = 25;
    public List<string> collisionTags;
    private void OnTriggerEnter(Collider otherCollider)
    {
        for (int i = 0; i < collisionTags.Count; i++)
        {
            if (otherCollider.gameObject.tag == collisionTags[i])
            {
                if(otherCollider.gameObject.tag == "Player")
                {
                    otherCollider.gameObject.GetComponent<PlayerHealth>().TakeDamage(hitDamage);
                }
            }
        }     
    }
}
