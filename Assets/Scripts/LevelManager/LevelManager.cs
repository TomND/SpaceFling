﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
   // Use this for initialization
   void Start()
   {
   }

   // Update is called once per frame
   void Update()
   {
   }

   public void LoadLevelOne()
   {
      Detector.ResetPlanets();
      Application.LoadLevel(Application.loadedLevel + 1);
   }
}
