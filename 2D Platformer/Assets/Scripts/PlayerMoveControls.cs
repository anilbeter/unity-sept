using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed;
    private GatherInput gI;
    private Rigidbody2D rb;
    private Animator anim;
    public float jumpForce;

    private int direction = 1;

    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    public bool isGrounded = true;
    public Transform rightPoint;

    // Start is called before the first frame update
    void Start()
    {
        gI = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorValues();
    }

    private void FixedUpdate()
    {
        Move();
        JumpPlayer();
        CheckStatus();
    }

    private void Move()
    {
        rb.velocity = new Vector2(speed * gI.valueX, rb.velocity.y);
        Flip();
    }

    private void JumpPlayer()
    {
        if (gI.jumpInput)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(gI.valueX * speed, jumpForce);
            }
        }
        gI.jumpInput = false;
    }

    private void CheckStatus()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightCheckHit = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);
        if (leftCheckHit || rightCheckHit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        SeeRays(leftCheckHit, rightCheckHit);
    }

    private void SeeRays(RaycastHit2D leftCheckHit, RaycastHit2D rightCheckHit)
    {
        Color color1 = leftCheckHit ? Color.red : Color.green;
        Color color2 = rightCheckHit ? Color.red : Color.green;
        Debug.DrawRay(leftPoint.position, Vector2.down * rayLength, color1);
        Debug.DrawRay(rightPoint.position, Vector2.down * rayLength, color2);
    }

    private void Flip()
    {
        if (direction * gI.valueX < 0)
        {
            direction = -direction;
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    private void SetAnimatorValues()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("verticalSpeed", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }
}
