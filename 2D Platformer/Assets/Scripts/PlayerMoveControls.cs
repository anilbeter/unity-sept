using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed;
    private GatherInput gI;
    private Rigidbody2D rb;

    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        gI = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(speed * gI.valueX, rb.velocity.y);
        Flip();
    }

    private void Flip()
    {
        if (direction * gI.valueX < 0)
        {
            direction = -direction;
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }
}