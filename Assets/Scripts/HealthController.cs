using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthController : ResourceClass
{   
    //Main resources
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
    public override void DisplayHealth(TMP_Text text)
    {
        text.text = "Health: " + Health;
    }
    public override void SetHealth(float h)
    {
        Health = h;
    }

    public override void SetMaxHealth(float mH)
    {
        MaxHealth = mH;
    }

    public override void Breathe()
    {
        //Not used with healthController
        throw new System.NotImplementedException();
    }

    public override void Death()
    {
        IsDead = true;
    }

    public override void TakeDamage(float damage)
    {
        Health = Health - damage;
    }
}
