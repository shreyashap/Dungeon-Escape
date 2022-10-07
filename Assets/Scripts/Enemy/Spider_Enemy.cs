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
        if (isDead == true)
            return;

        health--;

        if(health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");

            GameObject _diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            _diamond.GetComponent<Diamond>().gem = base.gem;


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
