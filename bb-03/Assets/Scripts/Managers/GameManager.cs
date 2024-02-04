using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton

    public static GameManager instance;

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
    void Update()
    {
        InputManager.instance.DetectInput();
        
        UIManager.instance.ClearWordBox();
        
        Level0.instance.CloseUI();
    }
}
