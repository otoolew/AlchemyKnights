using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemBehavior : MonoBehaviour {
    public List<string> pickUpWithTags = new List<string>();
    // Use this for initialization
 
    void OnTriggerEnter(Collider col)
    {
        for (int i = 0; i < pickUpWithTags.Count; i++)
        {
            if (col.gameObject.tag == pickUpWithTags[i])
            {
                try
                {
                    FindObjectOfType<GameData>().IncrementPlayerLevel();
                }
                catch (System.Exception)
                {
                    Debug.Log("No GameData Object Found.");
                    throw;
                }
                
                DestroyObject(gameObject);
            }
        }
    }
}
