using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [SerializeField] private Transform followObj;
    private Vector3 newPos;
    private float initY;

    private void Start()
    {
        initY = transform.position.y;
    }

    private void Update()
    {
        newPos.x = followObj.position.x;
        newPos.z = followObj.position.z;
        newPos.y = initY;
        transform.position = newPos;
    }
}
