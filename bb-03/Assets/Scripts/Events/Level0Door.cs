using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0Door : MonoBehaviour
{
    #region singleton

    public static Level0Door instance;

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

    public void Door()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            
        }
    }
}
