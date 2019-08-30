using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decaying : Destroyable
{
    public int decay = 1;

    void OnCollisionEnter2D(Collision2D other)
    {
        Damage(decay);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Damage(decay);
    }
}
