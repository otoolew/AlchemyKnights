using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrigger : MonoBehaviour {
    [HideInInspector]
    public int abilityDamage = 10;                         // Set the number of hitpoints that this gun will take away from shot objects with a health script.
    //private WaitForSeconds shotDuration = new WaitForSeconds(.07f);     // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible.
    private Animator anim;
    public void Initialize()
    {
        anim = GetComponent<Animator>();
    }

    public void Swing()
    {
        anim.SetTrigger("Attack");
    }

    //private IEnumerator SwingEffect()
    //{
    //    //Wait for .07 seconds
    //    yield return shotDuration;
    //    anim.SetTrigger("Attack");
    //}
}
