using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneOnEnter : MonoBehaviour {

    public string tagTrigger = "Player";
    public string scenetoLoad = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagTrigger)
            SceneManager.LoadScene(scenetoLoad);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == tagTrigger)
            SceneManager.LoadScene(scenetoLoad);       
    }
}
