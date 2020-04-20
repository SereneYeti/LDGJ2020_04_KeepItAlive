using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public Camera cam;
    public float verticalSpeed = 10f;
    public float horizontalSpeed = 10f;
    Vector3 playerPos;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerPos = player.transform.position;
        //if(player.transform.position != playerPos)
        //{
        //    this.transform.position = new Vector3(player.transform.position.x + 1f, 11f, player.transform.position.z - 13f);
        //}
        //this.transform.position = new Vector3(player.transform.position.x + 1f, 13.5f, player.transform.position.z - 13f);
        //this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+5f, player.transform.position.z-1);
        //yaw += speedH;

        //if(Input.GetKey(KeyCode.LeftControl))
        //{
        //    yaw++;
        //    transform.eulerAngles = new Vector3(45, yaw, 0.0f);
        //}
        
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    cam.transform.RotateAround(game_Manager.Instance.player.transform.position,Vector3.up,90);
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{

        //}
        //transform.Rotate(0, rotation, 0);

        //transform.LookAt(player.transform);
        //transform.Translate(Vector3.right * Time.deltaTime);

    }
}
