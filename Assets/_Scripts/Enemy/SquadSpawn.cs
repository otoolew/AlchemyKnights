using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadSpawn : MonoBehaviour {
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject enemyInstance = Instantiate(enemyPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
        }
        Destroy(gameObject, 1);
    }	
}
