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
    Vector2 mousePos;
    Vector3 target;
    float speed = 5f;

    private float lastShot;
    public float fireRate;

    public Texture2D texture;

    #region Health

    public float currentOxygen;
    public OxygenController oxygenController = new OxygenController(100f, 100f, 100f, 100f);
    public HealthController healthController = new HealthController(100f, 100f, 100f, 100f);
    public TextMeshProUGUI dispHealth;
    public TextMeshProUGUI disp02;
    #endregion
    public Camera cam;

    public NavMeshAgent agent;
    //public Rigidbody2D playerRB;

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
        game_Manager.Instance.healthBar.SetMaxHealth(Convert.ToInt32(healthController.Health));
        game_Manager.Instance.healthBar.SetHealth(Convert.ToInt32(healthController.Health));
    }

    public void Reset02(float max02)
    {
        oxygenController.SetMaxO2(max02);
        oxygenController.SetO2(max02);
        game_Manager.Instance.oxygenBar.SetMaxOxygen(Convert.ToInt32(max02));
        game_Manager.Instance.oxygenBar.SetOxygen(Convert.ToInt32(max02));
    }

    public void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Move our agent
                agent.SetDestination(new Vector3(hit.point.x, 1f, hit.point.z));
                idle.SetActive(false);
                Walking.SetActive(true);
            }

        }

    }

    public void Shoot()
    {
        //RaycastHit raycastHit;
        //Debug.Log("t");
        //if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out raycastHit))
        //{
        //    Debug.Log(raycastHit.transform.name);
        //}
        //Quaternion rotate = (firePoint.transform.rotation);
        ////Vector2 lookDir = mousePos - playerRB.position;

        //float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg;
        #region atempts to shoot on mousePos
        //float angle = Mathf.Atan(mousePos.z / mousePos.x);
        //Debug.Log(angle);
        //angle -= 90;
        //agent.transform.Rotate(new Vector3(0f,angle,0f),Space.World); 
        //agent.transform.rotation = Quaternion.Euler(0f,angle,0f);
        //agent.transform.Rotate(new Vector3(0f, agent.transform.rotation.y + Vector3.SignedAngle(playerRB.transform.position, Input.mousePosition, Vector3.up)));
        //agent.transform.rotation = Quaternion.Euler(new Vector3(0f, Vector3.Angle(playerRB.transform.position, Input.mousePosition), 0f));
        //rotate.y *= -1;
        #endregion
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, firePoint.transform.position.z + 0.5f), game_Manager.Instance.player.transform.rotation);
        Rigidbody rB = bullet.GetComponent<Rigidbody>();
        rB.AddForce(rB.transform.forward * bulletForce, ForceMode.Impulse);

    }

    public void LookAtMouse()
    {

        //Vector2 dir = mousePos - playerRB.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Deg2Rad;
        //playerRB.rotation = angle;
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
        Reset02(100f);
        currentOxygen = oxygenController.O2;
        healthController.DisplayHealth(dispHealth);
        idle.SetActive(true);
        Walking.SetActive(false);
        Cursor.SetCursor(texture, mousePos,CursorMode.ForceSoftware);
        Cursor.visible = true;
    }

    void Update()
    {
        currentOxygen = oxygenController.O2;
        if (!agent.hasPath)
        {
            idle.SetActive(true);
            Walking.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            agent.speed = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            agent.speed = 10f;
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

        if (Input.GetMouseButton(1) && (lastShot + fireRate <= Time.time))
        {
            lastShot = Time.time;
            Shoot();
        }

        oxygenController.Display02(disp02);
        oxygenController.Death(disp02);

        if(healthController.IsDead == true&& oxygenController.IsDead == false)
        {
            game_Manager.Instance.killedBy = "You died by beating!";
            game_Manager.Instance.finalHealth = healthController.Health;
            game_Manager.Instance.finalO2 = oxygenController.O2;
            SceneManager.LoadScene(2);
        }
        else if(oxygenController.IsDead == true&& healthController.IsDead == false)
        {
            game_Manager.Instance.killedBy = "You died by sufocation!";
            game_Manager.Instance.finalHealth = healthController.Health;
            game_Manager.Instance.finalO2 = oxygenController.O2;
            SceneManager.LoadScene(2);
        }
    }

    private void FixedUpdate()
    {
        LookAtMouse();

        if(Time.fixedTime % 1.5 ==0&&oxygenController.O2 > 0)
        {
            oxygenController.Breathe();
            game_Manager.Instance.oxygenBar.SetOxygen(Convert.ToInt32(oxygenController.O2));
            //Debug.Log(oxygenController.O2); 
            oxygenController.Display02(disp02);
            oxygenController.Death(disp02);
        }

    }


}
