using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Destroyable
{
    public float movementSpeed = 5f;
    public float movementRunningSpeed = 10f;

    public Rigidbody2D rb;

    private Vector2 movement;
    public Animator animator;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speedMultiplier = isRunning ? 2 : 1;

        float movementSpeed = Mathf.Clamp(movement.magnitude, 0.0f, 1.0f);

        animator.SetFloat("horizontal", Mathf.Clamp(mouse.x, -1, 1));
        animator.SetFloat("vertical", Mathf.Clamp(mouse.y, -1, 1));
        animator.SetFloat("speed", movementSpeed * speedMultiplier);
        animator.SetBool("isCasting", Input.GetKey(KeyCode.T));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    protected override void OnDeath()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        // TODO: add death animation
    }
}