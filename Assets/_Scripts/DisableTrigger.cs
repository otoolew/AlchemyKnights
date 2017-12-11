using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisableTrigger : MonoBehaviour {

    public CollisionType collisionMode = CollisionType.TriggerVsCollider;
    public List<string> collidesWithTags = new List<string>();
    public GameObject[] gameObjectsToDisable;

    void Start()
    {
        if (gameObjectsToDisable.Length == 0)
        {

        }
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
        if (collisionMode == CollisionType.ColliderVsCollider)
        {
            for (int i = 0; i < collidesWithTags.Count; i++)
            {
                if (col.gameObject.tag == collidesWithTags[i])
                {
                    
                    Debug.Log(this.name + " -> OnCollisionEnter");                  
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Test Entered Trigger");
        if (collisionMode != CollisionType.ColliderVsCollider)
        {
            for (int i = 0; i < collidesWithTags.Count; i++)
            {
                if (col.gameObject.tag == collidesWithTags[i])
                {
                    if (gameObjectsToDisable.Length == 0)
                        return;
                    else
                    {
                        foreach (GameObject go in gameObjectsToDisable)
                        {
                            go.SetActive(false);
                        }
                    }
                    //Debug.Log(this.name + " -> OnTriggerEnter");                  
                }
            }
        }

    }
    void OnTriggerExit(Collider col)
    {
        for (int i = 0; i < collidesWithTags.Count; i++)
        {
            if (col.gameObject.tag == collidesWithTags[i])
            {
                if (gameObjectsToDisable.Length == 0)
                    return;
                else
                {
                    foreach (GameObject go in gameObjectsToDisable)
                    {
                        go.SetActive(true);
                    }
                }
                Debug.Log(this.name + " -> OnTriggerExit");
            }
        }       
    }
}
