﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelsMenu : MonoBehaviour
{

    public void SelectLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
  
}
