using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControll : MonoBehaviour
{
    public float canisterFill = 10f;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {          
            PlayerController pC = game_Manager.Instance.player.GetComponent<PlayerController>();
            float temp = canisterFill;
            temp += pC.currentOxygen;
            if (temp>100)
            {
                pC.oxygenController.SetO2(100);
            }
            else
            {
                
                pC.oxygenController.SetO2(temp);
            }
            
           
            game_Manager.Instance.oxygenBar.SetOxygen(Convert.ToInt32(temp));

            Debug.Log(temp);
            Destroy(this.gameObject);
        }
        
    }
}
