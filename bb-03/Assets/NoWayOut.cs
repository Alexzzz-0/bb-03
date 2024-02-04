using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWayOut : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("playerA"))
        {
            UIManager.instance.Aempty = false;
            UIManager.instance.Aword.text = "There is no way out...";
        }
        
        if (other.gameObject.CompareTag("playerB"))
        {
            UIManager.instance.Bempty = false;
            UIManager.instance.Bword.text = "There is no way out...";
        }
    }
}
