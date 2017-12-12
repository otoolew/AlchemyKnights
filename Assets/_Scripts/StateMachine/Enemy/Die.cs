using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Die : EnemyBaseFSM {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //enemy.SetActive(false);
        enemy.GetComponent<CapsuleCollider>().enabled = false;
        enemy.GetComponent<NavMeshAgent>().enabled = false;
        Destroy(enemy, 2f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(navAgent.isActiveAndEnabled)
            navAgent.SetDestination(enemy.transform.position);
        //Debug.Log(enemy.name + " Die State");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //enemy.SetActive(false);
        //enemy.GetComponent<EnemyAI>().StopAttack();
    }
}
