using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFX : MonoBehaviour {

    public GameObject particleObject;

    public void EnableFX()
    {
        particleObject.SetActive(true);
    }
    public void DisableFX()
    {
        particleObject.SetActive(false);
    }


}
