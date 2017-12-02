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

    //Just need to find a way to call the correct set of lines based off of the players accomplishments
    public void Speak()
    {
        
        if(speakingDistance > Vector3.Distance(other.position, transform.position))
        {
            TakeAwayControls();
            if (false)  //if complete statue
            {
                rpgTalk.lineToStart = 20;
                rpgTalk.lineToBreak = 20;
                rpgTalk.callbackFunction = "GiveBackControls";
                rpgTalk.NewTalk();
            }
            else if (false)//if 2 pieces of statue recovered
            {
                rpgTalk.lineToStart = 17;
                rpgTalk.lineToBreak = 18;
                rpgTalk.callbackFunction = "GiveBackControls";
                rpgTalk.NewTalk();
            }
            else if (false)//if 1 piece of statue recovered
            {
                rpgTalk.lineToStart = 12;
                rpgTalk.lineToBreak = 15;
                rpgTalk.callbackFunction = "GiveBackControls";
                rpgTalk.NewTalk();
            }
            else   //if no pieces of statue recovered
            {
                rpgTalk.lineToStart = 6;
                rpgTalk.lineToBreak = 10;
                rpgTalk.callbackFunction = "GiveBackControls";
                rpgTalk.NewTalk();
            }
        }
        
    }
}
