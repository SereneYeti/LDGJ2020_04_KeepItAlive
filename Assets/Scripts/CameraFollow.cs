using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Collider player;

    Vector3 playerPos;
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
        this.transform.position = new Vector3(player.transform.position.x, 13.5f, player.transform.position.z);
    }
}
