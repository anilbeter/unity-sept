using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movingInput;

    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movingInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new(rb.velocity.x, jumpForce);
        }

        rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);
    }
}
