using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour {

    private Transform navTarget;               // Reference to the player's position.
    private NavMeshAgent navAgent;               // Reference to the nav mesh agent.
    private Animator animator;
    private EnemyHealth enemyHealth;
    
    public EnemyState enemyState;
    [HideInInspector]public Vector3 startingPosition;
    private float timer;
    public float cooldown = 1;


    void Awake()
    {
        // Set up the references.
        enemyHealth = GetComponent<EnemyHealth>();
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        navAgent.enabled = true;
        navTarget = transform;
        startingPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    void Update()
    {
        timer += Time.deltaTime;
        //if(navAgent.remainingDistance <= navAgent.stoppingDistance)
        //    animator.SetBool("IsMoving", false);
        //else
        //    animator.SetBool("IsMoving", true);
        switch (enemyState)
        {
            case EnemyState.Idle:
                animator.SetBool("IsMoving", false);
                break;
            case EnemyState.Chasing:
                animator.SetBool("IsMoving", true);
                navAgent.isStopped = false;
                navAgent.SetDestination(navTarget.position);
                var lookPos = navTarget.position - transform.position;
                lookPos.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = rotation;        
                if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                {
                    
                    if (timer >= cooldown)
                    {
                        StartCoroutine(HitPlayControl());
                        timer = 0;
                    }
                }
                break;
            case EnemyState.Returning:
                navAgent.SetDestination(startingPosition);
                if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                    enemyState = EnemyState.Idle;
                break;
            case EnemyState.Dead:
                navAgent.isStopped = true;
                break;     
        }      
    }
    public void SetNavTarget(Transform newTarget)
    {
        navTarget = newTarget;
    }

    IEnumerator HitPlayControl()
    {

        navAgent.isStopped = true;
        animator.SetBool("IsMoving", false);
        animator.SetTrigger("Attack");
        yield return new WaitForSecondsRealtime(0.2f);
        navAgent.isStopped = false;
    }

}
