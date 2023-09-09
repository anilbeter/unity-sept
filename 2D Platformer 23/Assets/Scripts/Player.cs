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
    private bool canMove;


    private Rigidbody2D rb;
    private Animator anim;

    private bool facingRight = true;
    private int facingDirection = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        MoveHorizontally();
    }

    void Update()
    {
        AnimationControllers();
        FlipController();
        CollisionCheck();

        InputChecks();

        if (isGrounded)
        {
            canDoubleJump = true;
            canMove = true;
        }


        if (canWallSlide)
        {
            isWallSliding = true;
            // Player will slower slide with rb.velocity.y * 0.1f code. I changed his y speed to times 1/10.
            rb.velocity = new(rb.velocity.x, rb.velocity.y * 0.1f);
        }

        if (!isTouchWall)
        {
            isWallSliding = false;
        }
    }

    private void AnimationControllers()
    {
        bool isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isSliding", isWallSliding);
    }

    private void InputChecks()
    {
        movingInput = Input.GetAxisRaw("Horizontal");

        // when player press either s or down arrow keys, then immediately stop sliding
        if (Input.GetAxis("Vertical") < 0)
            canWallSlide = false;

        if (Input.GetKeyDown(KeyCode.Space))
            JumpButton();
    }

    private void MoveHorizontally()
    {
        if (canMove)
            rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new(rb.velocity.x, jumpForce);
    }

    private void JumpButton()
    {
        if (isWallSliding)
            WallJump();

        else if (isGrounded)
            Jump();

        else if (canDoubleJump)
        {
            canDoubleJump = false;
            Jump();
        }
        canWallSlide = false; // line 59'daki conditionu devre dışı bırakmak için
    }

    private void WallJump()
    {
        canMove = false;
        rb.velocity = new(5 * -facingDirection, jumpForce);
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
        if (!isTouchWall)
            canWallSlide = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance, transform.position.z));

        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance, transform.position.y, transform.position.z));
    }
}
