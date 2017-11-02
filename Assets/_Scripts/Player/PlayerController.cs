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
    private Transform navTarget;
    private NavMeshAgent navAgent;
    private float distance;
    public LayerMask layerMask;
    private Ray ray;
    private RaycastHit rayHit;
    private float rayCastRange;
    private bool moving;
    private bool enemyClicked;
    public Transform launchPoint;
    public LineRenderer lineRender;
    public int HP;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        HP = 100;
    }

    private void Update()
    {
        if (navAgent.stoppingDistance > navAgent.remainingDistance)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
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
                animator.SetBool("IsMoving", false);
            }
        }
    }
}
