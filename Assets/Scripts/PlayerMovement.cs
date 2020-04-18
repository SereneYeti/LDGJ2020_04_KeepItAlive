using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    //public float moveSpeed = 5f;
    //public Rigidbody rb;
    //Vector3 movement = new Vector3();

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Movement()
    {
    //    movement.x =  Input.GetAxisRaw("Horizontal");
    //    movement.y = 0f;
    //    movement.z = Input.GetAxisRaw("Vertical");
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void Update()
    {
        //Movement();
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
    
}
