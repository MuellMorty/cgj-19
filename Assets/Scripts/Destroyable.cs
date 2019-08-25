using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public int maxHP;
    public int currHP;

    public bool IsDead()
    {
        return currHP <= 0;
    }

    public void Damage(int amount)
    {
        currHP -= amount;
        
        if (IsDead()) OnDeath();
    }

    public void Heal(int amount)
    {
        currHP = currHP + amount > maxHP ? maxHP : currHP + amount;
    }

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}
