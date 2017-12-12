using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBaseState : StateMachineBehaviour
{
    public GameObject player;
    public NavMeshAgent navAgent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;
        navAgent = player.GetComponent<NavMeshAgent>();
    }
}

