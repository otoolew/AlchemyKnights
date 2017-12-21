using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
//using UnityEditor;

public class PotionMasterSpeechControll : MonoBehaviour, IPointerClickHandler
{
    public RPGTalk rpgTalk;
    public GameObject player;
    public float speakingDistance = 10.0f;
    public int playerProgress;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //playerProgress = FindObjectOfType<GameData>().GetPlayerLevel();
        playerProgress = 0;
    }

    public void OnPointerClick(PointerEventData evd)
    {
        Speak();
    }

    public void DisableControls()
    {
        player.GetComponent<PlayerController>().enabled = false;
    }

    public void EnableControls()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }

    //Just need to find a way to call the correct set of lines based off of the players accomplishments
    public void Speak()
    {
        DisableControls();
        if (speakingDistance > Vector3.Distance(player.transform.position, transform.position))
        {
            DisableControls();
            if (playerProgress == 3)  //if complete statue
            {
                rpgTalk.lineToStart = 20;
                rpgTalk.lineToBreak = 21;
                rpgTalk.callbackFunction = "EnableControls";
                rpgTalk.NewTalk();
            }
            else if (playerProgress == 2)//if 2 pieces of statue recovered
            {
                rpgTalk.lineToStart = 17;
                rpgTalk.lineToBreak = 18;
                rpgTalk.callbackFunction = "EnableControls";
                rpgTalk.NewTalk();
            }
            else if (playerProgress == 1)//if 1 piece of statue recovered
            {
                rpgTalk.lineToStart = 12;
                rpgTalk.lineToBreak = 15;
                rpgTalk.callbackFunction = "EnableControls";
                rpgTalk.NewTalk();
            }
            else   //if no pieces of statue recovered
            {
                rpgTalk.lineToStart = 5;
                rpgTalk.lineToBreak = 10;
                rpgTalk.callbackFunction = "EnableControls";
                rpgTalk.NewTalk();
            }
        }
        EnableControls();
    }
}
