using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour {
    public int damage = 10;
    //public GameObject impactParticle;
    public GameObject projectileParticle;
    private bool hasCollided = false;
    public List<string> collidesWithTags = new List<string>();
    public CapsuleCollider capsuleCollider;

    void Start()
    {
        projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation) as GameObject;
        projectileParticle.transform.parent = transform;
    }
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Enemy" || hit.gameObject.tag == "Projectile")
            return;
        if (hit.gameObject.tag == "Player") // Projectile will destroy objects tagged as Destructible
        {
            hit.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        //transform.DetachChildren();
        Destroy(projectileParticle, 3f);
        //Destroy(impactParticle, 4f);
        Destroy(gameObject);
        //projectileParticle.Stop();      

    }
}
