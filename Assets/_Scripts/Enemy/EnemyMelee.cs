using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : MonoBehaviour {
    private Animator animator;
    private NavMeshAgent navAgent;
    private float timer;
    public float cooldown=1;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
        timer +=Time.deltaTime;
	}
    public void Swing()
    {
        if (timer >= cooldown)
        {
            StartCoroutine(HitPlayControl());
            timer = 0;
        }
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
