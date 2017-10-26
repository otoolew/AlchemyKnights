using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlindStatusEffect : MonoBehaviour {
    public Image image;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B");
            ApplyBlind();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C");
            CureBlind();
        }
    }
    public void ApplyBlind()
    {
        image.CrossFadeAlpha(1f, .1f, false);
    }
    public void CureBlind()
    {
        image.CrossFadeAlpha(0.1f, 2.0f, false);
    }
}
