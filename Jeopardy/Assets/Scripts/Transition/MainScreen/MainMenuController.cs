using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("LoadMusic");
    }

    public void ExitButtonClick(){
        Application.Quit();
    }

    public void PlayButtonClick(){

        SceneManager.LoadScene("PlayGame");
    }

    public void CreateEditButtonClick(){
       
        SceneManager.LoadScene("CreateEditGame");

    }
}
