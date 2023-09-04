using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour yerine Enemy yazdım. Şu an Enemy parent class, PatrollingEnemy child class oldu.
public class PatrollingEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-1, rb.velocity.y);
    }
}
