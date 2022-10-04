using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Enemy : Enemy , IDamagable
{
    public GameObject acidPrefab;
    public float health { get; set; }

    public override void Init()
    {
        base.Init();
        health = base.Health;
    }

    public override void Update()
    {
        
    }

    public override void Movement()
    {
        
    }
    public void Damage()
    {
        health--;

        if(health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            
        }
    }
    public void Attack()
    {
        StartCoroutine(FireAcid());
    }

    IEnumerator FireAcid()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(acidPrefab, transform.position, Quaternion.identity);

    }
}
