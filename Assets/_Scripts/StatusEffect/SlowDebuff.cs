using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowDebuff : MonoBehaviour {

    public float duration; // when it should expire?
    public float speedReduction;
    public float playerSpeed;
    public bool isActive = false;
    public GameObject particleEffect;
    [HideInInspector]
    public PlayerHealth playerHealth;
    [HideInInspector]
    public PlayerController playerController;
    //[HideInInspector]
    //public NavMeshAgent navAgent;
    // Use this for initialization
    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
        playerController = GetComponentInParent<PlayerController>();
        playerSpeed = playerController.movementSpeed;
    }

    public void ApplyEffect()
    {
        if (!isActive)
        {
            isActive = true;
            particleEffect.SetActive(true);
            playerController.movementSpeed = speedReduction;
            Invoke("EndEffect", duration);
        }
        else
        {
            //Debug.Log("Already Active");
        }

    }
    public void EndEffect()
    {
        CancelInvoke();
        isActive = false;
        playerController.movementSpeed = playerSpeed;
        particleEffect.SetActive(false);
    }
}
