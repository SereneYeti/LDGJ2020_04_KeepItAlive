﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public HealthController(){}

    public HealthController(float h, float mH, float _o2, float mO2)
    {
        Health = h;
        MaxHealth = mH;
        O2 = _o2;
        MaxO2 = mO2;        
    }

    public HealthController(float h, float mH, float _o2, float mO2, float gA, float ff )
    {
        Health = h;
        MaxHealth = mH;
        O2 = _o2;
        MaxO2 = mO2;
        GrenadeAmount = gA;
        FlamethrowerFuel = ff;
    }
    public override void DisplayHealth(TextMeshProUGUI text)
    {
        text.text = "Health: " + Health;
    }
    public override void SetHealth(float h)
    {
        Health = h;
        game_Manager.Instance.healthBar.SetHealth(Convert.ToInt32(Health));
    }

    public override void SetMaxHealth(float mH)
    {
        MaxHealth = mH;
        game_Manager.Instance.healthBar.SetHealth(Convert.ToInt32(MaxHealth));
    }

    public override void Breathe()
    {
        //Not used with healthController
        throw new System.NotImplementedException();
    }

    public override void Death(TMPro.TextMeshProUGUI text)
    {
        if(Health <= 0)
        {
            IsDead = true;
            text.text = "Dead";
        }        
    }

    public override void TakeDamage(float damage)
    {
        Health = Health - damage;
    }

    public override void Display02(TextMeshProUGUI text)
    {
        throw new System.NotImplementedException();
    }

    public override void SetO2(float O2)
    {
        throw new System.NotImplementedException();
    }

    public override void SetMaxO2(float mO2)
    {
        throw new System.NotImplementedException();
    }
}
