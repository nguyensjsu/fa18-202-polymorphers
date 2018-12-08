using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameButton : MonoBehaviour {

    public FileInfo file;
    public CreateGameController controller;

	// Use this for initialization
	void Start ()
	{
	    controller = GameObject.Find("CreateGameCanvas").GetComponent<CreateGameController>();
		Text text = gameObject.transform.GetComponentInChildren<Text>();
        text.text = file.Name;
        Button button = gameObject.transform.GetComponent<Button>();
        button.onClick.AddListener(() => controller.LoadGame(file));
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
