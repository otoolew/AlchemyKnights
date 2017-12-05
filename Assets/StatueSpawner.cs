using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is a super one time class to just spawn in the correct statue based off of
//the game manager
public class StatueSpawner : MonoBehaviour {
    public GameObject podium;
    public GameObject noWingsNoShield;
    public GameObject noWings;
    public GameObject fullStatue;
    public int playerProgress;
	// Use this for initialization
	void Start () {
        playerProgress = FindObjectOfType<GameData>().GetPlayerLevel();
        //waiting for game manager to properly implement these if statements.
        if (playerProgress == 3)  //if full statue
        {
            podium.SetActive(false);
            noWingsNoShield.SetActive(false);
            noWings.SetActive(false);
            fullStatue.SetActive(true);

        }else if (playerProgress == 2)    //if statue with no wings
        {
            podium.SetActive(false);
            noWingsNoShield.SetActive(false);
            noWings.SetActive(true);
            fullStatue.SetActive(false);
        }
        else if (playerProgress == 1)     //if statue with no wings and no shield
        {
            podium.SetActive(false);
            noWingsNoShield.SetActive(true);
            noWings.SetActive(false);
            fullStatue.SetActive(false);
        }
        else                //if no statue, just podium
        {
            podium.SetActive(true);
            noWingsNoShield.SetActive(false);
            noWings.SetActive(false);
            fullStatue.SetActive(false);
        }
    }
	

}
