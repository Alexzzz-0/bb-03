using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region singleton

    public static InputManager instance;

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
    
    private Transform transA;
    private Transform transB;
    private Rigidbody rbA;
    private Rigidbody rbB;

    private Vector3 Adir;
    private Vector3 Bdir;
    private Quaternion Aface;
    private Quaternion Bface;
    
    private float Ahorizontal;
    private float Avertical;
    private float Bhorizontal;
    private float Bvertical;
    
    public float Aforce;
    public float Bforce;
    public float rotateSpeed = 0.1f;
    
    public bool Amove = true;
    public bool Bmove = true;
    
    private void Start()
    {
        rbA = GameObject.FindWithTag("playerA").GetComponent<Rigidbody>();
        rbB = GameObject.FindWithTag("playerB").GetComponent<Rigidbody>();
        transA = GameObject.FindWithTag("playerA").GetComponent<Transform>();
        transB = GameObject.FindWithTag("playerB").GetComponent<Transform>();
    }

    public void DetectInput()
    {
        if (Amove)
        {
            Ahorizontal = Input.GetAxis("Horizontal");
            Avertical = Input.GetAxis("Vertical");

            Adir = new Vector3(Ahorizontal, 0, Avertical).normalized * Aforce;
            rbA.velocity = Adir;

            if (Adir != Vector3.zero)
            {
                Aface = Quaternion.LookRotation(Adir, Vector3.up);
                transA.rotation = Quaternion.Slerp(transA.rotation,Aface,Time.deltaTime * rotateSpeed);
            }
        }

        if (Bmove)
        {
            Bhorizontal = Input.GetAxis("HorizontalArrow");
            Bvertical = Input.GetAxis("VerticalArrow");

            Bdir = new Vector3(Bhorizontal, 0, Bvertical).normalized * Bforce;
            rbB.velocity = Bdir;

            if (Bdir != Vector3.zero)
            {
                Bface = Quaternion.LookRotation(Bdir, Vector3.up);
                transB.rotation = Quaternion.Slerp(transB.rotation, Bface, Time.deltaTime * rotateSpeed);
            }
        }
    }
    
}

