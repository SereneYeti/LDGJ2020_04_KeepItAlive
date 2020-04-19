using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
   
    public GameObject[] mapEdges;
    public GameObject map;
    GameObject temp;
    public GameObject[] mobs;
    public float SpawnRate = 2f;

    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = map.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Time.fixedTime%SpawnRate==0&game_Manager.Instance.mobCount<20)
        {
            Debug.Log("S");
            temp = Instantiate(mobs[0],GetRandomPos(),Quaternion.identity);
            
            if(UnityEngine.Random.Range(0,2) == 1)
            {
                WanderingAI aI = new WanderingAI();
                aI.RandomNavSphere(temp.transform.position, 50f);
            }
            game_Manager.Instance.mobs.Add(temp);
            game_Manager.Instance.mobCount++;
        }
        
        
    }

    Vector3 GetRandomPos()
    {
        float tempX;
        float tempZ;

        Vector3 randPos;

        //tempX = UnityEngine.Random.Range(Convert.ToInt32(mapEdges[0].transform.position.x), Convert.ToInt32(mapEdges[3].transform.position.x));
        //tempZ = UnityEngine.Random.Range(Convert.ToInt32(mapEdges[1].transform.position.z), Convert.ToInt32(mapEdges[2].transform.position.z));

        tempX = UnityEngine.Random.Range(-5,6);
        tempZ = UnityEngine.Random.Range(-5,6);

        randPos = new Vector3(tempX, 0f, tempZ);
        return randPos;
    }
}
