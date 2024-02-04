using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachHands : MonoBehaviour
{
    private GameObject slice;

    private void Start()
    {
        slice = GameObject.FindWithTag("slice");
    }

    private void Update()
    {
        transform.position = slice.transform.position;
    }
}
