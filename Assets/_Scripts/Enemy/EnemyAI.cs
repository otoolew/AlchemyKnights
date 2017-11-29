using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    AttackType attackType;
    Animator anim;
    GameObject player;
    NavMeshAgent navAgent;
    public float attackSpeed = 1f;
    public Transform firePoint;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
	}
    public GameObject GetPlayer()
    {
        return player;
    }
    public void SetNavAgentTarget(Transform target)
    {
        navAgent.SetDestination(target.position);
    }
    private void Attack()
    {
        if(attackType == AttackType.Ranged)
        {
            //GameObject projectile = Instantiate(projectile, )
        }
    }
    public void StartAttack()
    {
        InvokeRepeating("Attack", attackSpeed, attackSpeed);
    }
    public void StopAttack()
    {
        CancelInvoke("Attack");
    }
}
