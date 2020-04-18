using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody rb;


    Vector3 movement = new Vector3();
    private void Start()
    {
        
    }

    public void Movement()
    {
        movement.x =  Input.GetAxisRaw("Horizontal");
        movement.y = 0f;
        movement.z = Input.GetAxisRaw("Vertical");
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
    
}
