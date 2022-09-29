using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variable for rigidbody
    private Rigidbody2D playerRb;


    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    
    private bool jumpReset = false;
    private bool isGrounded = false;
    
    private PlayerAnimation playerAnimation;
    private SpriteRenderer playerSprite;
    private SpriteRenderer swordSprite;
    
    void Start()
    {
        //getting rigidbody reference
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerSprite =GetComponentInChildren<SpriteRenderer>();
        swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = OnGrounded();
        Movement();
        Attack();


  

    }

    void Movement()
    {
        //taking players horizontalInput
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && OnGrounded() == true)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            StartCoroutine(JumpReset());
            playerAnimation.Jump(true);
        }
        
        playerRb.velocity = new Vector2(horizontalInput *moveSpeed , playerRb.velocity.y);

        
        playerAnimation.Move(horizontalInput);

        if (horizontalInput > 0)
        {
            playerSprite.flipX = false;
            swordSprite.flipX = false;
            swordSprite.flipY = false;

            Vector3 newPos = swordSprite.transform.localPosition;
            newPos.x = 1.01f;
            swordSprite.transform.localPosition = newPos;
        }
        else if(horizontalInput < 0)
        {
            playerSprite.flipX = true;
            swordSprite.flipX = true;
            swordSprite.flipY = true;

            Vector3 newPos = swordSprite.transform.localPosition;
            newPos.x = -1.0f;
            
            swordSprite.transform.localPosition = newPos;

            
        }

    }

    bool OnGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 6);
       // Debug.DrawRay(transform.position, Vector2.down * 0.8f);

        if(hitInfo.collider != null)
        {
            if(jumpReset == false)
            {
                playerAnimation.Jump(false);
                return true;

            }
        }
             

        return false;
    }

    IEnumerator JumpReset()
    {
        jumpReset = true;

        yield return new WaitForSeconds(0.1f);

        jumpReset = false;

    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            playerAnimation.Attack();
            playerAnimation.SwordArc();
        }
    }
}
