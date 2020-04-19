using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LostClass 
{
    protected float health;
    protected float maxHealth;
    protected float damage;
    protected float agroRadius;
    protected bool isDead;

    public abstract void Attack(GameObject target);
    public abstract void TakeDamage(float dmg);
    
}
