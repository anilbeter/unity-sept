using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movingInput;

    [Header("Move Info")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Collision Info")]
    public LayerMask whatIsGround;
    public float groundCheckDistance;
    public float wallCheckDistance;
    private bool isGrounded;
    private bool canDoubleJump;
    private bool isTouchWall;
    private bool canWallSlide;
    private bool isWallSliding;


    private Rigidbody2D rb;
    private Animator anim;

    private bool facingRight = true;
    private int facingDirection = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        AnimationControllers();
        FlipController();
        CollisionCheck();

        InputChecks();

        if (isGrounded)
            canDoubleJump = true;
        MoveHorizontally();

        if (canWallSlide)
            isWallSliding = true;
    }

    private void AnimationControllers()
    {
        bool isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void InputChecks()
    {
        movingInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
            JumpButton();
    }

    private void JumpButton()
    {
        if (isGrounded)
            Jump();

        else if (canDoubleJump)
            canDoubleJump = false;
        Jump();
    }

    private void MoveHorizontally()
    {

        rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new(rb.velocity.x, jumpForce);
    }

    private void Flip()
    {
        facingDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, -180, 0);
    }

    private void FlipController()
    {
        if (facingRight && movingInput < 0)
            Flip();

        else if (!facingRight && movingInput > 0)
            Flip();

    }

    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);

        isTouchWall = Physics2D.Raycast(transform.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);
        // rb.velocity.y < 0 means player is falling
        if (isTouchWall && rb.velocity.y < 0)
            canWallSlide = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance, transform.position.z));

        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance, transform.position.y, transform.position.z));
    }
}
