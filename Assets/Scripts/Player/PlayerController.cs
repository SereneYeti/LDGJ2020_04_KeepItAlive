using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float damage = 10f;
    public float bulletForce = 20f;
    Vector3 mousePos;
    Vector3 target;
    float speed = 5f;

    private float lastShot;
    public float fireRate;

    #region Health
    public HealthBar healthBar;
    public HealthController healthController = new HealthController(100f,100f,100f,100f);
    public TextMeshProUGUI dispHealth;
    #endregion
    public Camera cam;

    public NavMeshAgent agent;
    public Rigidbody playerRB;

    #region bullet 
    public GameObject firePoint;
    public GameObject bulletPrefab;
    #endregion

    public GameObject idle;
    public GameObject Walking;
    public GameObject crosshairs;
    //public TheMaddenedUnit mU = new TheMaddenedUnit(10,10,10,10);

    public void ResetHealth(float maxHealth)
    {
        healthController.SetMaxHealth(maxHealth);
        healthController.SetHealth(maxHealth);
        healthBar.SetMaxHealth(Convert.ToInt32(healthController.Health));
        healthBar.SetHealth(Convert.ToInt32(healthController.Health));
    }

    public void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Move out agent
                agent.SetDestination(new Vector3(hit.point.x, 1f, hit.point.z));
                idle.SetActive(false);
                Walking.SetActive(true);                
            }

        }

    }
        
    public void Shoot()
    {
        RaycastHit raycastHit;
        Debug.Log("t");
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out raycastHit))
        {
            Debug.Log(raycastHit.transform.name);
        }
        Quaternion rotate = (firePoint.transform.rotation);
        Vector3 targetDir = mousePos - transform.position;

        float angle = Vector3.SignedAngle(targetDir, transform.forward,Vector3.up);        
        //float angle = Mathf.Atan(mousePos.z / mousePos.x);
        Debug.Log(angle);
        //angle -= 90;
        //agent.transform.Rotate(new Vector3(0f,angle,0f),Space.World); 
        //agent.transform.rotation = Quaternion.Euler(0f,angle,0f);
        //agent.transform.Rotate(new Vector3(0f, agent.transform.rotation.y + Vector3.SignedAngle(playerRB.transform.position, Input.mousePosition, Vector3.up)));
        //agent.transform.rotation = Quaternion.Euler(new Vector3(0f, Vector3.Angle(playerRB.transform.position, Input.mousePosition), 0f));
        //rotate.y *= -1;
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, firePoint.transform.position.z+0.5f), playerRB.rotation);
        Rigidbody rB = bullet.GetComponent<Rigidbody>();
        rB.AddForce(firePoint.transform.forward * bulletForce, ForceMode.Impulse);
        
    }

    public void LookAtMouse()
    {
        
        //Vector2 dir = new Vector2(mousePos.x, mousePos.z) - new Vector2(playerRB.position.x, playerRB.position.z);
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Deg2Rad;
        //playerRB.rotation.Set(0f, angle, 0f, playerRB.rotation.w);
        //transform.Rotate(transform.position, angle);
        //Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        //float midPoint = (transform.position - cam.transform.position).magnitude * 0.5f;
        //transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint,transform.position);
        /* Vector3 temp = (mouseRay.origin + mouseRay.direction * midPoint)*/
        ;
        //transform.rotation = Quaternion.
    }

    private void Start()
    {
        ResetHealth(100f);
        healthController.DisplayHealth(dispHealth);
        idle.SetActive(true);
        Walking.SetActive(false);
        //Cursor.visible = false;
    }

    void Update()
    {
        if(!agent.hasPath)
        {
            idle.SetActive(true);
            Walking.SetActive(false);
        }
                        

        Movement();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        #region Crosshair Attempt
        //crosshairs.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);

        //Vector3 difference = mousePos - transform.position;
        //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
        //transform.rotation = Quaternion.Euler(0.0f, rotationZ, 0.0f);
        #endregion

        healthController.Death(dispHealth);

        if (Input.GetMouseButton(1)&&(lastShot + fireRate <= Time.time))            
        {
            lastShot = Time.time;
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        //LookAtMouse();
        
    }

    
}
