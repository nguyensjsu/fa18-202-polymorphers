using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EditCategoryPanel : MonoBehaviour
{

    private Button EditQuestionButton;
    private Button EditCategoryButton;

    private void Awake()
    {
        EditQuestionButton = Resources.Load<Button>("Prefabs/EditQuestionButton");
        EditCategoryButton = Resources.Load<Button>("Prefabs/EditCategoryButton");
    }

    // Use this for initialization
	void Start ()
	{
	    Debug.Log(gameObject.transform.childCount);
	    Transform CategoryPanel = gameObject.transform.GetChild(0).transform;
	    Transform QuestionPanel = gameObject.transform.GetChild(1).transform;
	    
	    
	    // Create Category Panel
	    Button newCategory = Instantiate(EditCategoryButton);
	    newCategory.transform.SetParent(CategoryPanel, false);

	    // Create Question Panel
	    for (int i = 0; i < GameData.GameData.Row; i++)
	    {
	        Button newQuestion = Instantiate(EditQuestionButton);
	        newQuestion.name = "Question" + i;
	        newQuestion.transform.SetParent(QuestionPanel, false);
	    }
	    
//	    GameObject questionButton = gameObject.transform.GetChild(1).transform.GetChild(0).gameObject;
//	    Button newquestionButton = Instantiate(EditQuestionButton);
//	    newquestionButton.name += "1";
//	    newquestionButton.transform.SetParent(gameObject.transform.GetChild(1).transform, false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
