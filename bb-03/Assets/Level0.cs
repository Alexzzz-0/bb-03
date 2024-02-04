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

    public void CloseUI()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            A.SetActive(false);
            Apressed = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            S.SetActive(false);
            Spressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            D.SetActive(false);
            Dpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            W.SetActive(false);
            Wpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UP.SetActive(false);
            UPpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DOWN.SetActive(false);
            DOWNpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LEFT.SetActive(false);
            LEFTpressed = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RIGHT.SetActive(false);
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
    }
}
