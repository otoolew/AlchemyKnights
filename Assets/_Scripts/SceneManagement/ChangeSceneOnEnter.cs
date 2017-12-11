using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneOnEnter : MonoBehaviour {

    public string tagTrigger = "Player";
    public string sceneToLoad = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagTrigger)
            SceneManager.LoadScene(sceneToLoad);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == tagTrigger)
            SceneManager.LoadScene(sceneToLoad);       
    }
}
