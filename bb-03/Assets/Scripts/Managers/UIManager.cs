using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI Aword;
    public TextMeshProUGUI Bword;
    public GameObject footStep;
    public GameObject knockDoor;

    #region singleton

    public static UIManager instance;

    private void Start()
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

    public bool Aempty = true;
    public bool Bempty = true; 
    public float timerA;
    public float timerB;
    
    public void ClearWordBox()
    {
        if (!Aempty)
        {
            timerA += Time.deltaTime;
            if (timerA >= 2f)
            {
                Aword.text = null;
                Aempty = true;
            }
        }
        
        if (!Bempty)
        {
            timerB += Time.deltaTime;
            if (timerB >= 2f)
            {
                Bword.text = null;
                Bempty = true;
            }
        }
    }
}
