using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Vector3 stuckPos;
    public GameObject animation;
    private GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerA"))
        {
            //find the obj
            obj = GameObject.FindWithTag("playerA");
            
            //move to the right place and start animation
            obj.SetActive(false);
            obj.transform.position = stuckPos;
            animation.SetActive(true);
            
            //disable the movement
            InputManager.instance.Amove = false;
            
            //trigger the instruction to wait
            Level0.instance.playerAReached = true;
            
            //open the sound effect
            UIManager.instance.knockDoor.SetActive(true);
            
        }
        
        if (other.CompareTag("playerB"))
        {
            //find the obj
            obj = GameObject.FindWithTag("playerB");
            
            //move to the right place and start animation
            obj.SetActive(false);
            obj.transform.position = stuckPos;
            animation.SetActive(true);
            
            //disable the movement
            InputManager.instance.Bmove = false;
            
            //trigger the instruction to wait
            Level0.instance.playerBReached = true;
            
            //open the sound effect
            UIManager.instance.knockDoor.SetActive(true);
        }
    }
}
