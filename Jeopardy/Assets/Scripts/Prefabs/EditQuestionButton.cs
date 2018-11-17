using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditQuestionButton : MonoBehaviour
{
	public JQuestion QuestionInfo;
	
	// Use this for initialization
	void Start ()
	{
		Text text = gameObject.transform.GetComponentInChildren<Text>();
		text.text = "$" + QuestionInfo.Value;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
