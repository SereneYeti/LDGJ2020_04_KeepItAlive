using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OxygenController : ResourceClass
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

    public OxygenController(float h, float mH, float _o2, float mO2)
    {
        Health = h;
        MaxHealth = mH;
        O2 = _o2;
        MaxO2 = mO2;
    }

    public override void DisplayHealth(TextMeshProUGUI text)
    {
        text.text = "";
    }

    public override void Display02(TextMeshProUGUI text)
    {
        text.text = "Oxygen: " + O2;
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
        if (02 >= 0)
        {
            O2 = O2 - 2;
        }
        
    }

    public override void Death(TMPro.TextMeshProUGUI text)
    {
        if (O2 <= 0)
        {
            IsDead = true;
            text.text = "Dead";
        }
    }

    public override void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public override void SetO2(float o2)
    {
        O2 = o2;
        game_Manager.Instance.oxygenBar.SetOxygen(Convert.ToInt32(O2));
    }

    public override void SetMaxO2(float mO2)
    {
        MaxO2 = mO2;
        game_Manager.Instance.oxygenBar.SetOxygen(Convert.ToInt32(MaxO2));
    }
}
