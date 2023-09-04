using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    // protected olan variablelar sadece parent ve child tarafından erişilebilir. Inspector'dan erişmem mümkün değil
    protected Rigidbody2D rb;
    protected Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
