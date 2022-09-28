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
    private PlayerAnimation playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        //getting rigidbody reference
        playerRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        Movement();


  

    }

    void Movement()
    {
        //taking players horizontalInput
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && OnGrounded() == true)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            StartCoroutine(JumpReset());
        }
        playerRb.velocity = new Vector2(horizontalInput *moveSpeed , playerRb.velocity.y);

    }

    bool OnGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 6);

        if(hitInfo.collider != null)
        {
            if(jumpReset == false)
              return true;
        }

        return false;
    }

    IEnumerator JumpReset()
    {
        jumpReset = true;

        yield return new WaitForSeconds(0.1f);

        jumpReset = false;

    }
}
