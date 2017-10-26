using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private Vector3 destination;
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

    // AWAKE METHOD
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        HP = 100;
        destination = transform.position;
        navAgent.SetDestination(destination);
    }

    private void Update()
    {
        distance = navAgent.remainingDistance - navAgent.stoppingDistance;
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!navAgent.hasPath || Mathf.Abs(navAgent.velocity.sqrMagnitude) < float.Epsilon)
            {
                moving = false;
                animator.SetBool("IsMoving", moving);
            }
        }
        else
        {
            moving = true;
            animator.SetBool("IsMoving", moving);
        }
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f, layerMask))
                {
                    var lookPos = hit.point - transform.position;
                    lookPos.y = 0;
                    Quaternion rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = rotation;
                    moving = true;
                    navAgent.destination = hit.point;
                    navAgent.isStopped = false;
                }
            }
        }
        if (Input.GetMouseButton(1))
        {
            //Debug.Log("Mouse 1");
            navAgent.SetDestination(transform.position);
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, this.transform.position.y, Input.mousePosition.z);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rayHit, 100, layerMask))
            {
                //Vector3 hitPoint = rayHit.point;
                //launchPoint.transform.LookAt(rayHit.point);
                //if (rayHit.point != null)
                //{
                var lookPos = rayHit.point - transform.position;
                lookPos.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = rotation;
                Vector3 hitPoint = rayHit.point;
                Vector3 vector = new Vector3(0, 1, 0);
                var newPoint = hitPoint + vector;
                //launchPoint.transform.LookAt(rayHit.point);
                launchPoint.transform.LookAt(newPoint);

                //Debug.Log(rayHit.point);
                animator.SetBool("IsMoving", moving);
                //}
            }
        }
    }

}
