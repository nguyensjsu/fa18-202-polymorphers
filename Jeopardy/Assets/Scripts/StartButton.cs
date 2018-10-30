﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    public void StartGame(string LevelName)
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
