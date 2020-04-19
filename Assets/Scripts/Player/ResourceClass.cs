using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class ResourceClass
{
    //Main resources
    protected float health;
    protected float maxHealth;
    protected float o2;
    protected float maxO2;
    protected bool isDead;

    //Ammo needed to be picked up
    protected float grenadeAmount;
    protected float flamethrowerFuel;

    //Methods
    public abstract void TakeDamage(float damage);
    public abstract void SetHealth(float h);
    public abstract void SetMaxHealth(float mH);
    public abstract void DisplayHealth(TextMeshProUGUI text);
    public abstract void Breathe();
    public abstract void Death(TMPro.TextMeshProUGUI text);



}
