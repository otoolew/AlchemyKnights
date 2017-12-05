using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour {
    public GameObject itemDropPrefab;
    public bool dropped = false;

    public void Drop()
    {
        if(dropped == false)
        {
            dropped = true;
            itemDropPrefab = Instantiate(itemDropPrefab, gameObject.transform.position, gameObject.transform.rotation);
        } 
    }
}
