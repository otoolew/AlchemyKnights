using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navAgent;
    private PlayerAbility playerAbility;
    public LayerMask layerMask;
    private Ray ray;
    private RaycastHit rayHit = new RaycastHit();
    public Transform launchPoint;
    private bool moving = false;
    
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
        if (Input.GetKeyDown(KeyCode.L)){
            FindObjectOfType<GameData>().IncrementPlayerLevel();
            FindObjectOfType<GameData>().DebugGameData();
        }
   
        if (navAgent.isActiveAndEnabled)
        {
            if (Input.GetMouseButton(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    animator.SetBool("Casting", false);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 100f, layerMask))
                    {
                        animator.SetBool("Moving", true);
                        navAgent.destination = hit.point;
                        navAgent.isStopped = false;
                    }
                }
            }
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                animator.SetBool("Moving", false);
            }

            if (Input.GetMouseButton(1))
            {
                // MOVE TO STATE CODE
                animator.SetBool("Moving", false);
                animator.SetBool("Casting",true);
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
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                animator.SetBool("Casting", false);
            }

        }
    }
}
