using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppet : MonoBehaviour {
    public Animator _animator;
	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("Damage");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _animator.SetTrigger("Die");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            _animator.SetBool("IsMoving", true);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            _animator.SetBool("IsMoving", false);
        }
    }
}
