using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
    public GameObject bossPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        int randomSpawnPoint = Random.Range(1, spawnPoints.Length);
        Debug.Log("Boss Spawned "+ randomSpawnPoint +" "+ spawnPoints[randomSpawnPoint].position);
        GameObject bossInstance = Instantiate(bossPrefab, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
    }
}
