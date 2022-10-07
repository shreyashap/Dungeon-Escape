using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnim;
    [SerializeField] private Animator swordAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
   
    public void Move(float move)
    {
        playerAnim.SetFloat("Move",Mathf.Abs(move));
    }

    public void Jump(bool isJumping)
    {
        playerAnim.SetBool("isJumping", isJumping);
    }

    public void Attack()
    {
        playerAnim.SetTrigger("Attack");
    }

    public void SwordArc()
    {
        swordAnim.SetTrigger("SwordArc");
    }

    public void Death()
    {
        playerAnim.SetTrigger("Death");
    }
    
}
