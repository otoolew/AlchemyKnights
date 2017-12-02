using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEditor;

public class PotionMasterSpeechControll : MonoBehaviour, IPointerClickHandler
{

    public RPGTalk rpgTalk;

    public MonoBehaviour[] ItemsToTurnOff;

    public Transform other;
    public float speakingDistance = 10.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnPointerClick(PointerEventData evd)
    {
        Speak();
    }

    public void TakeAwayControls()
    {
        for (int i = 0; i < ItemsToTurnOff.Length; i++)
        {
            ItemsToTurnOff[i].enabled = false;
        }
    }

    public void GiveBackControls()
    {
        for (int i = 0; i < ItemsToTurnOff.Length; i++)
        {
            ItemsToTurnOff[i].enabled = true;
        }
    }

    public void Speak()
    {
        TakeAwayControls();
        if(speakingDistance > Vector3.Distance(other.position, transform.position))
        {
            if (false)  //if complete statue
            {

            }
            else if (false)//if 2 pieces of statue recovered
            {

            }
            else if (false)//if 1 piece of statue recovered
            {

            }
            else   //if no pieces of statue recovered
            {
                rpgTalk.lineToStart = 6;
                rpgTalk.lineToBreak = 10;
                rpgTalk.callbackFunction = "GiveBackControls";
                rpgTalk.NewTalk();
                print("Talking");
            }
        }
        
    }
}
