using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navAgent;
    private PlayerAbility playerAbility;
    public LayerMask layerMask;
    private Ray ray;
    private RaycastHit rayHit;
    public Transform launchPoint;
    public LineRenderer lineRender;
      
    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerAbility = GetComponent<PlayerAbility>();
        navAgent.enabled = true;
        navAgent.SetDestination(transform.position);
    }

    private void Update()
    {
        if (!navAgent.isActiveAndEnabled)
            return;
        if (navAgent.stoppingDistance > navAgent.remainingDistance)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Running", false);
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Running", true);
        }

        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {          
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
          
                if (Physics.Raycast(ray, out hit,100f,layerMask))
                {
                    navAgent.SetDestination(hit.point);
                    navAgent.isStopped = false;
                }
            }
        }
        if (Input.GetMouseButton(1))
        {
            //Debug.Log("Mouse 1");
            navAgent.SetDestination(transform.position);
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.z);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rayHit, 100, layerMask))
            {
 
                var lookPos = rayHit.point - transform.position;
                lookPos.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = rotation;
                Vector3 hitPoint = rayHit.point;
                Vector3 vector = new Vector3(0, 1, 0);
                var newPoint = hitPoint + vector;

                launchPoint.transform.LookAt(newPoint);
                //Debug.Log(rayHit.point);              
            }
        }
        // For Debug
        if (Input.GetKey(KeyCode.A))
            animator.SetTrigger("Attack");
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Casting", true);
        }

    }
    public void DeathSequence()
    {
        navAgent.enabled = false;
        playerAbility.enabled = false;
        // Trigger Damage Animation
        animator.SetTrigger("Death");
    }
}
