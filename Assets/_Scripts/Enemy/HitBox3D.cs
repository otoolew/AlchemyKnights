using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBox3D : MonoBehaviour {

    public List<string> collidesWithTags = new List<string>();
    public CapsuleCollider capsuleCollider;
    public int randomRoll;
    public string statusInflicted;
    public int damage;
    void OnTriggerEnter(Collider col)
    {
        for (int i = 0; i < collidesWithTags.Count; i++)
        {
            if (col.gameObject.tag == collidesWithTags[i])
            {
                col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                randomRoll = Random.Range(0, 3);
                if (Random.Range(0, 3) == 2)
                {
                    //Debug.Log(Random.Range(0, 3));
                    
                    switch (statusInflicted)
                    {
                        case "Poison":
                            FindObjectOfType<PoisonDebuff>().ApplyEffect();
                            break;
                        case "Blind":
                            FindObjectOfType<BlindStatusEffect>().ApplyBlind();
                            break;
  
                        default:
                            
                            break;
                    }
                    //Debug.Log("Status");
                }

            }
        }     
    }
    public void DisableHitBox()
    {

    }
}
