using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : ResourceClass
{
    //Main resources
    public float Heath
    {
        get { return base.health; }
        set { base.health = value; }
    }

    public float MaxHeath
    {
        get { return base.maxHealth; }
        set { base.maxHealth = value; }
    }

    public float O2
    {
        get { return base.o2; }
        set { base.o2 = value; }
    }

    public float MaxO2
    {
        get { return base.maxO2; }
        set { base.maxO2 = value; }
    }

    public bool IsDead
    {
        get { return base.isDead; }
        set { base.isDead = value; }
    }

    //Ammo needed to be picked up
    public float GrenadeAmount
    {
        get { return base.grenadeAmount; }
        set { base.grenadeAmount = value; }
    }

    public float FlamethrowerFuel
    {
        get { return base.flamethrowerFuel; }
        set { base.flamethrowerFuel = value; }
    }

    public override void Breathe()
    {
        throw new System.NotImplementedException();
    }

    public override void Death()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
