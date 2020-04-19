using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            EnemyController eC = collision.gameObject.GetComponent<EnemyController>();

            if(eC != null)
            {
                PlayerController pc = game_Manager.Instance.player.GetComponent<PlayerController>();
                eC.mU.TakeDamage(pc.damage);
                eC.Death(collision.gameObject);
            }
        }
        catch {}
        
    }
}
