using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    public int damage = 1;
    public float damageWait = 0.5f;

    private float damageTimer = 0f;
    private bool attackWait = false;
    
    private Collider2D trigger;
    
    void Start()
    {
        trigger = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if (!attackWait) return;

        if (damageWait < damageTimer) attackWait = false;
        
        damageTimer += Time.fixedDeltaTime;
    }

    private void DoDamage(Destroyable other)
    {
        if (attackWait) return;

        attackWait = true;
        damageTimer = 0;
        
        other.Damage(damage);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Destroyable d)) DoDamage(d);
    }
}
