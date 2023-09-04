using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// MonoBehaviour yerine Enemy yazdım. Şu an Enemy parent class, PatrollingEnemy child class oldu.
public class PatrollingEnemy : Enemy
{
    public float speed;
    private int direction = -1;

    public Transform groundcheck;
    public Transform wallCheck;
    public LayerMask layerToCheck;

    private bool detectGround;
    private bool detectWall;

    public float radius;

    void Start()
    {

    }

    void FixedUpdate()
    {
        Flip();
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private void Flip()
    {
        // Draw circle for detection ground
        detectGround = Physics2D.OverlapCircle(groundcheck.position, radius, layerToCheck);
        // Draw circle for detection wall
        detectWall = Physics2D.OverlapCircle(wallCheck.position, radius, layerToCheck);

        if (detectWall || !detectGround)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }
}
