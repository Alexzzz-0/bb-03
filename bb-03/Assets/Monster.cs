using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float maxForce;
    public float mass;
    public int index;
    
    private Transform playerA;
    private Transform playerB;
    private Vector3 steering;
    private Vector3 desiredVelocity;
    private Vector3 currentVelocity;
    private float Adis;
    private float Bdis;
    private bool touch = false;
    
    private void Start()
    {
        playerA = GameObject.FindWithTag("playerA").transform;
        playerB = GameObject.FindWithTag("playerB").transform;
    }
    private void Update()
    {
        if (!touch)
        {
            Adis = Vector3.Distance(transform.position, playerA.position);
            Bdis = Vector3.Distance(transform.position, playerB.position);
            
            if (Adis < Bdis)
            {
                desiredVelocity = playerA.position - transform.position;
            }
            else
            {
                desiredVelocity = playerB.position - transform.position;
            }

            steering = desiredVelocity * maxForce * Time.deltaTime - currentVelocity;

            steering = steering / mass;

            currentVelocity = currentVelocity + steering;

            transform.position += currentVelocity;
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!touch)
        {
             if (other.gameObject.CompareTag("playerA"))
             {
                 touch = true;
                 SFXController.instance.pink.SetActive(false);
                 SFXController.instance.pink.transform.position = other.gameObject.transform.position;
                 SFXController.instance.pink.SetActive(true);
                 Vector3 newScale = other.gameObject.transform.localScale;
                 newScale -= Vector3.one * 10;
                 other.gameObject.transform.localScale = newScale;
                 if (newScale.x <= 0)
                 {
                     GameManager.instance.gameRunning = false;
                     SFXController.instance.ShowDefeat();
                     Debug.Log("die");
                 }
                 else
                 {
                     //InputController.instance.Aforce -= 3;
                     Debug.Log("hit");
                 }
             }
        
             if (other.gameObject.CompareTag("playerB"))
             {
                 touch = true;
                 SFXController.instance.blue.SetActive(false);
                 SFXController.instance.blue.transform.position = other.gameObject.transform.position;
                 SFXController.instance.blue.SetActive(true);
                 Vector3 newScale = other.gameObject.transform.localScale;
                 newScale -= Vector3.one * 10;
                 other.gameObject.transform.localScale = newScale;
                 if (newScale.x <= 0)
                 {
                     GameManager.instance.gameRunning = false;
                     SFXController.instance.ShowDefeat();
                     Debug.Log("die");
                 }
                 else
                 {
                     //InputController.instance.Bforce -= 3;
                     Debug.Log("hit");
                 }
             }
         }
        
         if (other.gameObject.CompareTag("slice"))
         {
             SFXController.instance.blood.SetActive(false);
             SFXController.instance.blood.transform.position = transform.position;
             SFXController.instance.blood.SetActive(true);
             switch (index)
             {
                 case 0:
                     GameManager.instance.Monster1.SetActive(true);
                     break;
                 case 1:
                     GameManager.instance.Monster2.SetActive(true);
                     GameManager.instance.Monster3.SetActive(true);
                     break;
                 case 2:
                     if (GameManager.instance.kill)
                     {
                         SFXController.instance.ShowWin();
                     }
                     else
                     {
                         GameManager.instance.kill = true;
                     }
                     break;
             }
             gameObject.SetActive(false);
             
         }
    }
}
