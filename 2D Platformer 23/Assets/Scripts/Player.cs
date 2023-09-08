using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movingInput;

    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;

    public LayerMask whatIsGround;
    public float groundCheckDistance;
    private bool isGrounded;
    private bool canDoubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        CollisionCheck();

        InputChecks();

        if (isGrounded)
        {
            canDoubleJump = true;
        }
        MoveHorizontally();
    }

    private void InputChecks()
    {
        movingInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpButton();
        }
    }

    private void JumpButton()
    {
        if (isGrounded)
        {
            Jump();
        }
        else if (canDoubleJump)
        {
            canDoubleJump = false;
            Jump();
        }
    }

    private void MoveHorizontally()
    {

        rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new(rb.velocity.x, jumpForce);
    }

    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance, transform.position.z));
    }
}
