using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour {
    public GameObject itemDropPrefab;
    public Transform dropPoint;
    public bool dropped = false;

    public void Drop()
    {
        if(dropped == false)
        {
            dropped = true;
            itemDropPrefab = Instantiate(itemDropPrefab, dropPoint.transform.position, dropPoint.transform.rotation);
        } 
    }
}
