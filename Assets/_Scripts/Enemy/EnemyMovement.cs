using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class EnemyMovement : MonoBehaviour {
    private Transform player;               // Reference to the player's position.
    private PlayerHealth playerHealth;      // Reference to the player's health.
    private EnemyHealth enemyHealth;        // Reference to this enemy's health.
    private NavMeshAgent navAgent;               // Reference to the nav mesh agent.
    private Animator animator;
    public UnityEvent OnAttack;
    public CollisionType collisionMode = CollisionType.TriggerVsCollider;
    public List<string> collidesWithTags = new List<string>();

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        navAgent.enabled = true;
    }
    void Update()
    {
         
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            navAgent.isStopped = false;
            navAgent.SetDestination(player.position);
            var lookPos = player.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                OnAttack.Invoke();               
            }
            else
            {
                animator.SetBool("IsMoving", true);
            }          
        }
    }
 
}
