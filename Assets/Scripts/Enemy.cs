using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : Destroyable
{
    public LayerMask blockLayer;
    public float speed = 0.5f;
    public float attackWait = 0.5f;
    private bool attackCD;
    private float attackTimer;
    
    private Transform target;
    private Vector2 dir;

    private Rigidbody2D rb;
    private Animator animator;
    private static readonly int Attack = Animator.StringToHash("Attack");

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var position = target.position;

        var hit = Physics2D.Linecast(transform.position, position, blockLayer);
        
        if (hit.transform != null)
            // TODO: handle target out of sight
            return;
        
        dir = position;
    }


    private void FixedUpdate()
    {
        if (attackCD) {
            if (attackTimer < attackWait )
            {
                attackTimer += Time.fixedDeltaTime;
            }
            else
            {
                attackTimer = 0;
                attackCD = false;
            }
        }
        
        var pos = Vector3.MoveTowards(rb.position, dir, speed * Time.deltaTime);
        rb.MovePosition(pos);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        dir = rb.position;

        if (attackCD) return;
        
        animator.SetTrigger(Attack);
        attackCD = true;
    }

    protected override void OnDeath()
    {
        Destroy(gameObject);
    }
}
