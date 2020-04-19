using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMaddenedUnit : LostClass
{    
    public float Health
    {
        get { return base.health; }
        set { base.health = value; }
    }

    public float MaxHealth
    {
        get { return base.maxHealth; }
        set { base.maxHealth = value; }
    }

    public float Damage
    {
        get { return base.damage; }
        set { base.damage = value; }
    }

    public float AgroRadius
    {
        get { return base.agroRadius; }
        set { base.agroRadius = value; }
    }

    public bool IsDead
    {
        get { return base.isDead; }
        set { base.isDead = value; }
    }

    public TheMaddenedUnit(float h, float mH, float d, float aR)
    {
        Health = h;
        MaxHealth = mH;
        Damage = d;
        AgroRadius = aR;
    }
    public override void Attack(GameObject target)
    {
        PlayerController pC = target.GetComponentInChildren<PlayerController>();

        float tempHealth = pC.healthController.Health;
        tempHealth -= Damage;
        pC.healthController.SetHealth(tempHealth);
        pC.healthController.DisplayHealth(pC.dispHealth);
    }
    public override void TakeDamage(float dmg)
    {
        Health = Health - dmg;
    }
}
