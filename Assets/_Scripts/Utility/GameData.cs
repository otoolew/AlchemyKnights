using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
    public int playerLevel;

    void Start () {
        playerLevel = GetPlayerLevel();
    }
	public int GetPlayerLevel()
    {
        return playerLevel;
    }
    public void SetPlayerLevel(int level)
    {
        playerLevel = level;
    }
    public void IncrementPlayerLevel()
    {
        playerLevel++;
    }
    public void DebugGameData()
    {
        Debug.Log("GameData: Player Level: " + playerLevel);
    }

}
