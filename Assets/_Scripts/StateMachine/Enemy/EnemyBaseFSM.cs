using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseFSM : StateMachineBehaviour {
    public GameObject enemy;
    public GameObject player;
    public NavMeshAgent navAgent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.gameObject;
        player = enemy.GetComponent<EnemyAI>().GetPlayer();
        navAgent = enemy.GetComponent<NavMeshAgent>();
    }
}
