using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Destroyable
{
    public float movementSpeed = 5f;
    public float movementRunningSpeed = 10f;
    public float movementMalus = 0.3f;
    
    public bool isRunning = false;
    public bool isCasting = false;

    public Rigidbody2D rb;

    private Vector2 movementInput;
    public Animator animator;

    public Vector2 diff;

    private void Update()
    {
        setState();
            
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        diff = mouse - transform.position;

        setAnimatorState();
    }

    private void FixedUpdate()
    {
        movement();
    }

    public void setAnimatorState()
    {
        animator.SetFloat("horizontal", Mathf.Clamp(diff.x, -1, 1));
        animator.SetFloat("vertical", Mathf.Clamp(diff.y, -1, 1));
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isCasting", isCasting);
    }

    private void setState()
    {
        isCasting = Input.GetKey(KeyCode.T);
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }

    private void movement()
    {
        rb.MovePosition(rb.position + movementInput * calcMovementSpeed() * Time.fixedDeltaTime);
    }

    private float calcMovementSpeed()
    {
        float currentMovementSpeed = movementSpeed;

        if (isRunning)
        {
            currentMovementSpeed = movementRunningSpeed;
        }

        if (isCasting)
        {
            currentMovementSpeed *= movementMalus;
        }

        return currentMovementSpeed;
    }

    protected override void OnDeath()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        // TODO: add death animation
    }
}