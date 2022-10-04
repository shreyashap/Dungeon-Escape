using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gem;
    [SerializeField] protected Transform pointA, pointB;

    protected Animator anim;
    protected Vector3 currentTarget;
    protected SpriteRenderer sprite;

    protected bool isHit = false;
    protected Player player;

    protected bool isDead = false;


    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    // Start is called before the first frame update

    private void Start()
    {
        Init();
    }


    // Update is called once per frame
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("inCombat") == false)
        {
            return;
        }

        if(isDead == false)
        {
            Movement();
        }
      
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }


        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");


        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");


        }

        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector2.Distance(transform.localPosition, player.transform.localPosition);

        Vector2 direction = player.transform.localPosition - transform.localPosition;

        if (distance >= 2.0f)
        {
            isHit = false;
            anim.SetBool("inCombat", false);
        }

        if (direction.x > 0 && anim.GetBool("inCombat") == true)
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("inCombat") == true)
        {
            sprite.flipX = true;
        }

    }





}
