using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float distance;

    Transform target;
    NavMeshAgent agent;

    //public GameObject zombIdle;
    //public GameObject zombWalk;
    //public GameObject zombAttack;

    public TheMaddenedUnit mU = new TheMaddenedUnit(15f,15f,10f,10f);
    // Start is called before the first frame update
    void Start()
    {
        //zombIdle.SetActive(false);
        //zombWalk.SetActive(true);
        //zombAttack.SetActive(true);
        target = game_Manager.Instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        this.transform.position = new Vector3(this.transform.position.x, 2.47f, this.transform.position.z);

        //Part of AI Spawn
        objSpawn = (GameObject)GameObject.FindWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position != null && transform.position != null)
        {
            distance = Vector3.Distance(target.position, transform.position);
        }

        

        if(distance <= lookRadius)
        {
            //zombIdle.SetActive(false);
            //zombWalk.SetActive(true);
            //zombAttack.SetActive(false);

            agent.SetDestination(target.position);
        }        
        
    }    

    public void Death(GameObject unit)
    {
        if (mU.Health <= 0)
        {
            mU.IsDead = true;
        }
        if(mU.IsDead == true)
        {
            game_Manager.Instance.mobCount--;
            game_Manager.Instance.lostKilled++;
            Destroy(unit);
        }
        
    }

    private void FixedUpdate()
    {
        //NOTE - Fixed updates Fixed Timestamp has been changed from 0.02 to 0.2 - Changed BACK
        if(Time.fixedTime%1==0)
        {
            if (distance <= 2f)
            {
                //zombIdle.SetActive(false);
                //zombWalk.SetActive(false);
                //zombAttack.SetActive(true);
                mU.Attack(game_Manager.Instance.player);
            }
        }        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    #region AISpawn
    // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Filename: AISpawn.cs
    //  
    // Author: Garth "Corrupted Heart" de Wet <mydeathofme[at]gmail[dot]com>
    // Website: www.CorruptedHeart.co.cc
    // 
    // Copyright (c) 2010 Garth "Corrupted Heart" de Wet
    //  
    // Permission is hereby granted, free of charge (a donation is welcome at my website), to any person obtaining a copy
    // of this software and associated documentation files (the "Software"), to deal
    // in the Software without restriction, including without limitation the rights
    // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    // copies of the Software, and to permit persons to whom the Software is
    // furnished to do so, subject to the following conditions:
    // 
    // The above copyright notice and this permission notice shall be included in
    // all copies or substantial portions of the Software.
    // 
    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    // THE SOFTWARE.
    // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
 

    private GameObject objSpawn;
    private int SpawnerID;
    // Used to find the parent spawner object
    
        
    
    // Call this when you want to kill the enemy
    void removeMe()
    {
        objSpawn.BroadcastMessage("killEnemy", SpawnerID);
        Destroy(gameObject);
    }
    // this gets called in the beginning when it is created by the spawner script
    void setName(int sName)
    {
        SpawnerID = sName;
    }

    #endregion
}
