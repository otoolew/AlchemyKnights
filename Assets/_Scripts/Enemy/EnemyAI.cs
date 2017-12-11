using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    public AttackType attackType;
    Animator anim;
    GameObject player;
    NavMeshAgent navAgent;
    public int healthPoints = 100;
    public float attackSpeed = 1f;
    public Transform firePoint;
    public GameObject projectile;
    public float launchForce = 0f;
    public float attackRange;
    public float attackCoolDown = 1f;
    private float timer = 0f;
    public bool dead;
    public bool isBoss;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
        attackRange = navAgent.stoppingDistance;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        anim.SetFloat("DetectRange", Vector3.Distance(transform.position, player.transform.position));
        // Check if in Attack Range
        if(Vector3.Distance(transform.position, player.transform.position)< attackRange)       
            anim.SetBool("AttackRange", true);     
        else
            anim.SetBool("AttackRange", false);

        if (healthPoints <= 0)
        {           
            anim.SetTrigger("Die");
            if (isBoss)
            {
                DropLoot dropLoot = GetComponent<DropLoot>();
                dropLoot.Drop();
                dropLoot.dropped = true;
            }
            
        }                   
	}
    public GameObject GetPlayer()
    {
        return player;
    }
    public void SetNavAgentTarget(Transform target)
    {
        navAgent.SetDestination(target.position);
    }
    public void Attack()
    {
        if (timer < attackCoolDown)
            return;     
        if (attackType == AttackType.Ranged)
        {
            if (timer < attackCoolDown)
            {
                Debug.Log("Nope");
            }
            else
            {              
                GameObject projectileInstance = Instantiate(projectile, firePoint.position, firePoint.rotation);
                projectileInstance.GetComponent<Rigidbody>().velocity = launchForce * firePoint.forward;
            }
        }
        timer = 0;
    }
    public void StartAttack()
    {
        InvokeRepeating("Attack", 0, attackSpeed);
    }
    public void StopAttack()
    {
        CancelInvoke("Attack");
    }
    public void TakeDamage(int amount)
    {
        healthPoints-=amount;
        anim.SetTrigger("Hit");
    }
}
