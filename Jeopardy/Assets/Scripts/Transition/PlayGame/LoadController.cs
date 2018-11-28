using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour {

    private GameObject loadGameObject;

	// Use this for initialization
	void Start () {
        loadGameObject = GameObject.Find("LoadGameOverlay");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadButtonClick()
    {
        loadGameObject.SetActive(false);
    }
}
