using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QAGameAudienceController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        //GameObject.Find("AnswerPanel").GetComponentInChildren<Text>().text = "123456";

    }

    public void UpdateContent(bool isAnswer)
    {
        if(isAnswer)
        {
            GameObject.Find("AnswerPanel").GetComponentInChildren<Text>().text = "Answer";

        }
        else
        {
            GameObject.Find("AnswerPanel").GetComponentInChildren<Text>().text = "Question";

        }
    }


}
