using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class AudienceController : MonoBehaviour {

    private Text redText;
    private Text blueText;


    // Use this for initialization
    void Start () {
        redText = GameObject.Find("Team1Score").GetComponent<Text>();
        blueText = GameObject.Find("Team2Score").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void setScore(object args)
    {
        object[] objects = (object[])args;
        string score = (string)objects[1];
        string isRed = (string)objects[0];
        if(isRed == "1")
        {
            redText.text = score;
        }
        else
        {
            blueText.text = score;
        }
    }
}
