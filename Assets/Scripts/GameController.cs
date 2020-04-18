using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour
{

    public HealthBar healthBar;
    public HealthController healthController = new HealthController();
    public TMP_Text dispHealth;

    private static GameController instance;

    public static GameController Instance
    {
        get { return instance; }
        set { }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    public void ResetHealth(float maxHealth)
    {
        healthController.SetMaxHealth(maxHealth);
        healthController.SetHealth(maxHealth);
        healthBar.SetMaxHealth(Convert.ToInt32(healthController.Health));
        healthBar.SetHealth(Convert.ToInt32(healthController.Health));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ResetHealth(100f);
        healthController.DisplayHealth(dispHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float tempH = healthController.Health--;
            healthController.SetHealth(tempH);
        }        
        healthController.DisplayHealth(dispHealth);
        
    }
}
