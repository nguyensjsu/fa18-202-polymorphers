using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateNewGameButton : MonoBehaviour
{
    public void CreateNewGame(string LevelName)
    {
        SceneManager.LoadScene("CreateGame", LoadSceneMode.Single);
    }
}
