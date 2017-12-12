using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastLoadState : PlayerBaseState {

    private PlayerController playerController;
    private Ray ray;
    private RaycastHit rayHit = new RaycastHit();

    public GameObject projectilePrefab;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //playerController =  player.GetComponent<PlayerController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (Input.GetMouseButtonUp(1))
        //{
        //    animator.SetBool("Casting", false);
        //}
        //else
        //{
        //    navAgent.SetDestination(player.transform.position);
        //    Vector3 mousePosition = new Vector3(Input.mousePosition.x, player.transform.position.y, Input.mousePosition.z);
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out rayHit, 100, playerController.layerMask))
        //    {
        //        var lookPos = rayHit.point - player.transform.position;
        //        lookPos.y = 0;
        //        Quaternion rotation = Quaternion.LookRotation(lookPos);
        //        player.transform.rotation = rotation;
        //        Vector3 hitPoint = rayHit.point;
        //        Vector3 vector = new Vector3(0, 1, 0);
        //        var newPoint = hitPoint + vector;
        //        playerController.launchPoint.transform.LookAt(newPoint);
        //    }
        //}

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
