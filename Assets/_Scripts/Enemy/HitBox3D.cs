using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBox3D : MonoBehaviour {

    public CollisionType collisionMode = CollisionType.TriggerVsCollider;
    [Tooltip("The cooldown time between collision events.")]
    public float Cooldown = 1f;
    public List<string> collidesWithTags = new List<string>();
    public float MinCollisionForce = 0f;
    float currentCooldown = 0f;

    void Update()
    {
        if (currentCooldown > 0)
            currentCooldown -= Time.deltaTime;
    }
    public void TestHit()
    {
        Debug.Log("Test Hit.");
    }
    public void TestEnter()
    {
        Debug.Log("Test Enter");
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Test Entered Collision");
        if (collisionMode == CollisionType.ColliderVsCollider && currentCooldown <= 0)
        {
            for (int i = 0; i < collidesWithTags.Count; i++)
            {
                if (col.gameObject.tag == collidesWithTags[i])
                {
                    Debug.Log("Test Hit Collision");
                    col.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Test Entered Trigger");
        if (collisionMode != CollisionType.ColliderVsCollider && currentCooldown <= 0)
        {
            for (int i = 0; i < collidesWithTags.Count; i++)
            {
                if (col.gameObject.tag == collidesWithTags[i])
                {
                    Debug.Log("Test Hit Trigger");
                    currentCooldown = Cooldown;
                }
            }
        }
    }
}
