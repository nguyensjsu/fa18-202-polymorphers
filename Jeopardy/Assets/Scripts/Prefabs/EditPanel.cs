using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPanel : MonoBehaviour
{

	private GameObject EditPanelPrefab;

	private void Awake()
	{
		EditPanelPrefab = Resources.Load<GameObject>("Prefabs/EditQuestionPanel");
	}

	// Use this for initialization
	void Start () {
		// Create Question Panel
		for (int i = 0; i < GameData.Column; i++)
		{
			var newPanel = Instantiate(EditPanelPrefab);
			newPanel.name = "Panel" + i;
			newPanel.GetComponent<EditQuestionPanel>().Column = i;
			newPanel.transform.SetParent(this.transform, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
