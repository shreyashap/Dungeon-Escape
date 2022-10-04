using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Enemy : Enemy , IDamagable
{
    public float health { get; set; }
    public override void Init()
    {
        base.Init();
        health = base.Health;
    }
    public override void Update()
    {
        base.Update();
    }

    public override void Movement()
    {
        base.Movement();

        
    }

    public void Damage()
    {
        Debug.Log("Skeleton Damage");

        health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("inCombat", true);

        if(health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            
        }
    }
 
}
