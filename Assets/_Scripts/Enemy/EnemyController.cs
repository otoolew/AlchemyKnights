using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour {

    private Transform navTarget;               // Reference to the player's position.
    private NavMeshAgent navAgent;               // Reference to the nav mesh agent.
    private Animator animator; 
    public EnemyState enemyState;
    [HideInInspector]public Vector3 startingPosition;
    private float timer;
    public float cooldown = 1;
    public int healthPoints;
    private CapsuleCollider capCollider;
    void Awake()
    {
        // Set up the references.
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        capCollider = GetComponent<CapsuleCollider>();
    }
    private void Start()
    {
        healthPoints = 100;
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
                    navAgent.isStopped = true;
                    if (timer >= cooldown)
                    {                       
                        animator.SetTrigger("Attack");
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
                transform.Translate(-Vector3.up * 0.2f * Time.deltaTime);
                break;     
        }      
    }
    public void SetNavTarget(Transform newTarget)
    {
        navTarget = newTarget;
    }
    public void TakeDamage(int amount)
    {
        healthPoints -= amount;
        
        // If the enemy is dead...
        if (healthPoints <= 0)
        {
            animator.SetTrigger("Die");
            enemyState = EnemyState.Dead;
            capCollider.isTrigger = true;
            StartCoroutine(Death());
            return;
        }
        // Play the hurt sound effect.
        //enemyAudio.Play();
       animator.SetTrigger("Damage");
        //StartCoroutine(Hit());
    }
    IEnumerator Hit()
    {
        navAgent.isStopped = false;
        navAgent.destination = transform.position;
        yield return new WaitForSecondsRealtime(0.2f);
    }
    IEnumerator Death()
    {
        animator.SetTrigger("Die");
        navAgent.destination = transform.position;
        yield return new WaitForSecondsRealtime(2f);
        Destroy(gameObject);
    }

}
