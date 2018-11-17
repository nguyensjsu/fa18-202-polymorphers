using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditCategoryButton : MonoBehaviour {

	public string Category { get; set; }
	// Use this for initialization
	void Start () {
		Text text = gameObject.transform.GetComponentInChildren<Text>();
		text.text = Category;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
