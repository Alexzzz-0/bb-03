using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : MonoBehaviour
{
    [SerializeField] private GameObject W;
    [SerializeField] private GameObject A;
    [SerializeField] private GameObject S;
    [SerializeField] private GameObject D;
    [SerializeField] private GameObject UP;
    [SerializeField] private GameObject DOWN;
    [SerializeField] private GameObject LEFT;
    [SerializeField] private GameObject RIGHT;
    [SerializeField] private Outline leftOne;
    [SerializeField] private Outline leftTwo;
    [SerializeField] private Outline rightOne;
    [SerializeField] private Outline rightTwo;
    //[SerializeField] private Material materialBehindDoor;

    public bool playerAReached = false;
    public bool playerBReached = false;
    private Color newColor;
    private float transDecrease = 0.05f;
    
    private bool Wpressed = false;
    private bool Apressed = false;
    private bool Spressed = false;
    private bool Dpressed = false;
    private bool UPpressed = false;
    private bool DOWNpressed = false;
    private bool LEFTpressed = false;
    private bool RIGHTpressed = false;

    private float AoutLine;
    private float BoutLine;
    #region singleton

    public static Level0 instance;
    
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    // private void Start()
    // {
    //     newColor = materialBehindDoor.color;
    //     newColor.a = 1;
    // }

    public void CloseUI()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //the more they pressed, the more transparent the wall
            // if (!Apressed)
            // {
            //     newColor = materialBehindDoor.color;
            //     newColor.a -= transDecrease;
            //     materialBehindDoor.color = newColor;
            // }
            
            //if they pressed when they are stuck, tell them dont move
            TellAToWait();
            
            //A.SetActive(false);
            Apressed = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // if (!Spressed)
            // {
            //     newColor = materialBehindDoor.color;
            //     newColor.a -= transDecrease;
            //     materialBehindDoor.color = newColor;
            // }
            TellAToWait();
            //S.SetActive(false);
            Spressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // if (!Dpressed)
            // {
            //     newColor = materialBehindDoor.color;
            //     newColor.a -= transDecrease;
            //     materialBehindDoor.color = newColor;
            // }
            TellAToWait();
            //D.SetActive(false);
            Dpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            // if (!Wpressed)
            // {
            //     newColor = materialBehindDoor.color;
            //     newColor.a -= transDecrease;
            //     materialBehindDoor.color = newColor;
            // }
            TellAToWait();
            //W.SetActive(false);
            Wpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // if (!UPpressed)
            // {
            //     newColor = materialBehindDoor.color;
            //     newColor.a -= transDecrease;
            //     materialBehindDoor.color = newColor;
            // }
            TellBToWait();
            //UP.SetActive(false);
            UPpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // if (!DOWNpressed)
            // {
            //     newColor = materialBehindDoor.color;
            //     newColor.a -= transDecrease;
            //     materialBehindDoor.color = newColor;
            // }
            TellBToWait();
            //DOWN.SetActive(false);
            DOWNpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // if (!LEFTpressed)
            // {
            //     newColor = materialBehindDoor.color;
            //     newColor.a -= transDecrease;
            //     materialBehindDoor.color = newColor;
            // }
            TellBToWait();
            //LEFT.SetActive(false);
            LEFTpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // if (!RIGHTpressed)
            // {
            //     newColor = materialBehindDoor.color;
            //     newColor.a -= transDecrease;
            //     materialBehindDoor.color = newColor;
            // }
            TellBToWait();
            //RIGHT.SetActive(false);
            RIGHTpressed = true;
        }

        if (Apressed && Wpressed && Spressed && Dpressed)
        {
            AoutLine += Time.deltaTime * 3;
            leftOne.OutlineWidth = AoutLine;
            leftTwo.OutlineWidth = AoutLine;
            if (AoutLine >= 10)
            {
                AoutLine = 0;
            }
        }

        if (UPpressed & DOWNpressed && LEFTpressed && RIGHTpressed)
        {
            BoutLine += Time.deltaTime * 3;
            rightOne.OutlineWidth = BoutLine;
            rightTwo.OutlineWidth = BoutLine;
            if (BoutLine >= 10)
            {
                BoutLine = 0;
            }
        }

        if (playerAReached && playerBReached)
        {
            //start next scene
            UIManager.instance.footStep.SetActive(false);
            Debug.Log("level 1");
        }
        
    }
    void TellAToWait()
    {
        if (playerAReached)
        {
            UIManager.instance.Aword.text = "We are waiting for the other.";
            UIManager.instance.timerA = 0;
            UIManager.instance.Aempty = false;
        }
    }
        
    void TellBToWait()
    {
        if (playerBReached)
        {
            UIManager.instance.Bword.text = "We are waiting for the other.";
            UIManager.instance.timerB = 0;
            UIManager.instance.Bempty = false;
        }
    }
}
