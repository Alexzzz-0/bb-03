using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region test

    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;
    public bool kill = false;

    #endregion
    
    #region singleton

    public static GameManager instance;
    public bool gameRunning = true;

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
        
        //UIManager.instance.ClearWordBox();
        
        //Level0.instance.CloseUI();
        
        PostProcessingController.instance.VignetteCenterControl();

        if (Input.GetKeyDown(KeyCode.R))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }
    }

    
}
