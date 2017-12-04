using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {
    public ProjectileType projectileType;
    private SphereCollider sphereCollider;
    private EnemyHealth enemyHealth;
    public int damage;
    public float blastRadius;
    public GameObject projectileParticle;
    public GameObject muzzleParticle;
    public GameObject impactParticle;

    void Start()
    {      
        Destroy(gameObject, 5f);
        sphereCollider = gameObject.GetComponent<SphereCollider>();
    }
    void OnCollisionEnter(Collision hit)
    {     
        if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "Projectile")
            return;
        sphereCollider.isTrigger = true;
              
        switch (projectileType)
        {
            case ProjectileType.Precision:
                if (hit.gameObject.tag == "Enemy") // Projectile will destroy objects tagged as Destructible
                {
                    
                    enemyHealth = hit.gameObject.GetComponentInParent<EnemyHealth>();
                    enemyHealth.TakeDamage(damage);
                }
                break;
            case ProjectileType.Area:
                ExplosionDamage(transform.position,blastRadius);
                break;
        }


        Destroy(projectileParticle, 3f);
        Destroy(impactParticle, 4f);
        Destroy(gameObject);       
    }
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag == "Enemy") // Projectile will destroy objects tagged as Destructible
            {
                Debug.Log("Blast Hit " + hitColliders[i].gameObject.name);
                enemyHealth = hitColliders[i].gameObject.GetComponentInParent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
            }
            i++;
        }
    }
}
