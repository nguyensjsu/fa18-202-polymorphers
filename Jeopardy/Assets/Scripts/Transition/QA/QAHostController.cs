using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class QAHostController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("PlayGame");
    }

    public void StartButtonClick()
    {

    }
}
