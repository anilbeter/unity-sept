using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private GatherInput gatherInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gatherInput = GetComponent<GatherInput>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * gatherInput.directionX, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        speed = 0;
    }
}
