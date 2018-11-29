using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour {

    private GameObject loadGameObject;

	void Start () {
        loadGameObject = GameObject.Find("LoadGameOverlay");
	}

    public void LoadButtonClick()
    {
        loadGameObject.SetActive(false);
    }
}
