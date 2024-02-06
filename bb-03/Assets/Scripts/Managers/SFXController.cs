using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SFXController : MonoBehaviour
{
   #region singleton

   public static SFXController instance;

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

   public GameObject pink;
   public GameObject blue;
   public GameObject blood;
   public TextMeshProUGUI title;
   public TextMeshProUGUI instructor;
   
   public void ShowDefeat()
   {
      title.text = "DEAD";
      instructor.text = "R to restart";
   }

   public void ShowWin()
   {
      title.text = "WIN";
      instructor.text = "R to restart";
   }
}
