using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EditQuestionPanel : MonoBehaviour
{

	public int Column { get; set; }
    private GameObject EditCategoryButtonPrefab, EditQuestionButtonPrefab;

    private void Awake()
    {
	    Column = 1;
        EditQuestionButtonPrefab = Resources.Load<GameObject>("Prefabs/EditQuestionButton");
        EditCategoryButtonPrefab = Resources.Load<GameObject>("Prefabs/EditCategoryButton");
    }

    // Use this for initialization
	void Start ()
	{
	    var CategoryPanel = gameObject.transform.GetChild(0).transform;
	    var QuestionPanel = gameObject.transform.GetChild(1).transform;
	    
	    // Create Category Panel
	    var newCategory = Instantiate(EditCategoryButtonPrefab);
	    newCategory.transform.SetParent(CategoryPanel, false);
		newCategory.GetComponent<EditCategoryButton>().Category = GameData.Category[Column];

	    // Create Question Panel
	    for (int i = 0; i < GameData.Row; i++)
	    {
	        var newQuestion = Instantiate(EditQuestionButtonPrefab);
	        newQuestion.name = "Question" + i;
		    newQuestion.GetComponent<EditQuestionButton>().QuestionInfo = GameData.Question[Column][i];
	        newQuestion.transform.SetParent(QuestionPanel, false);
	    }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
