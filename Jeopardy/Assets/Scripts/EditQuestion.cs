using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditQuestion : MonoBehaviour {

    public GameObject editPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update () {
		
	}

    public void OpenQuestionEditPanel()
    {
        string answer = EventSystem.current.currentSelectedGameObject.gameObject.transform.Find("AnswerText").GetComponent<Text>().text;
        editPanel.SetActive(true);
        editPanel.transform.Find("InputField").GetComponent<InputField>().text = answer;

        //pass this button to the edit panel so this button can be updated
        editPanel.GetComponent<CloseQuestionEditPanel>().button = gameObject.GetComponent<Button>();
    }
}
