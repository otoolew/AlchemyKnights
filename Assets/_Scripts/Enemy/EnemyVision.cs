using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyVision : MonoBehaviour {
    private EnemyController enemyController;
    private NavMeshAgent navAgent;
    private void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
        navAgent = GetComponentInParent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {      
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger Enter" + other.gameObject);

            enemyController.SetNavTarget(other.gameObject.transform); 
            enemyController.enemyState = EnemyState.Chasing;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger Exit" + other.gameObject);

            enemyController.enemyState = EnemyState.Returning;
        }
    }
}
