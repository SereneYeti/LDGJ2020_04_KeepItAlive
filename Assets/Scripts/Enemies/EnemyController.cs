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

    public TheMaddenedUnit mU = new TheMaddenedUnit(10f,10f,5f,10f);
    // Start is called before the first frame update
    void Start()
    {
        target = game_Manager.Instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        this.transform.position = new Vector3(this.transform.position.x, 2.47f, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
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
                mU.Attack(game_Manager.Instance.player);
            }
        }        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
