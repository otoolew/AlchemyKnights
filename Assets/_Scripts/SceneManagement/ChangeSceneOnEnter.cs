using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneOnEnter : MonoBehaviour {

    public string tag = "Player";
    public string nextScene = "";

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tag)
        {
            //Call Change scene
            print("Trigger Entered");
            loadScene();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == tag)
        {
            //call Change scene
            //print("Collision");
            loadScene();
        }
    }

    private void loadScene()
    {
        if (Application.isEditor)
        {
            loadEditorScene();
        }
        else
        {
            if (nextScene != "")
            {
                SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
            }
            else
            { /*If no next scene then do nothing*/
                print("No Scene to Load");
            }
        }
    }

    private void loadEditorScene()
    {
        print("Loading scenes is not supported while in editor.");
    }
}
