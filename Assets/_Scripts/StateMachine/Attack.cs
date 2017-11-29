using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : EnemyBaseFSM {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enemy.GetComponent<EnemyAI>().StartAttack();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.transform.LookAt(player.transform.position);
        //Debug.Log(enemy.name + " Attack State : Attacking " + player.name);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //enemy.GetComponent<EnemyAI>().StopAttack();
    }
}
