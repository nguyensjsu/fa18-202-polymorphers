using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SavedGamesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitSavedGamesController(){
        SceneManager.LoadScene("MainMenu");

    }

    public void PlayButtonClick(){
        SceneManager.LoadScene("PlayGame");
    }
}
