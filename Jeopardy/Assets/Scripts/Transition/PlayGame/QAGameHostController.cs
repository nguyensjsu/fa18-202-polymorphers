﻿using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QAGameHostController : MonoBehaviour {

    private GameObject gameHostObject;
    private GameObject audienceObject;
    private GameObject wagerObject;
    private GameObject qaGameAudienceObject;

    private int currentAddRedScore;
    private int currentAddBlueScore;

    bool isRed;

    bool isFirstShowScreen = true;


    // Use this for initialization
    void Start () {
        gameHostObject = GameObject.Find("GameHostScreen");
        audienceObject = GameObject.Find("GameAudienceScreen");
        wagerObject = GameObject.Find("SetWagerOverlay");
        qaGameAudienceObject = GameObject.Find("QAGameAudienceScreen");
    }

    // Update is called once per frame
    void Update () {
	
	}

    private void OnEnable()
    {
        if (isFirstShowScreen)
        {
            isFirstShowScreen = false;
            return;
        }

        AudienceData audienceData = AudienceData.GetInstance();
        currentAddRedScore = audienceData.GetAddRedScore();
        currentAddBlueScore = audienceData.GetAddBlueScore();
        //set score and team
        GameObject.Find("RedAddButton").GetComponentInChildren<Text>().text = "+" + currentAddRedScore.ToString();
        GameObject.Find("RedSubtractButton").GetComponentInChildren<Text>().text = "-" + currentAddRedScore.ToString();
        GameObject.Find("BlueAddButton").GetComponentInChildren<Text>().text = "+" + currentAddBlueScore.ToString();
        GameObject.Find("BlueSubtractButton").GetComponentInChildren<Text>().text = "-" + currentAddBlueScore.ToString();
        GameObject.Find("RedText").GetComponentInChildren<Text>().text = audienceData.GetRedTeamName();
        GameObject.Find("BlueText").GetComponentInChildren<Text>().text = audienceData.GetBlueTeamName();
    }

    public void ExitQAHostButtonClick()
    {
        gameObject.SetActive(false);
        audienceObject.SendMessage("changePanel", "ExitQuestion");
    }

    public void RedAddScoreButtonClick()
    {
        //music
        FindObjectOfType<AudioManager>().Play("Applaud");

        int currentRedScore = AudienceData.GetInstance().GetRedScore();
        currentRedScore += currentAddRedScore;
        AudienceData.GetInstance().SetRedTeamScore(currentRedScore);

        gameHostObject.SendMessage("UpdateTeamScore");
    }

    public void RedSubtractButtonClick()
    {
        //music
        FindObjectOfType<AudioManager>().Play("Sad");

        int currentRedScore = AudienceData.GetInstance().GetRedScore();
        currentRedScore -= currentAddRedScore;
        AudienceData.GetInstance().SetRedTeamScore(currentRedScore);

        gameHostObject.SendMessage("UpdateTeamScore");
    }



    public void BlueAddScoreButtonClick()
    {
        //music
        FindObjectOfType<AudioManager>().Play("Applaud");

        int currentBlueScore = AudienceData.GetInstance().GetBlueScore();

        currentBlueScore += currentAddBlueScore;
        AudienceData.GetInstance().SetBlueTeamScore(currentBlueScore);


        gameHostObject.SendMessage("UpdateTeamScore");
    }

    public void BlueSubtractButtonClick()
    {
        //music
        FindObjectOfType<AudioManager>().Play("Sad");

        int currentBlueScore = AudienceData.GetInstance().GetBlueScore();

        currentBlueScore -= currentAddBlueScore;
        AudienceData.GetInstance().SetBlueTeamScore(currentBlueScore);

        gameHostObject.SendMessage("UpdateTeamScore");
    }

    public void RedWagerButtonClick()
    {
        isRed = true;
        wagerObject.SetActive(true);
        InputField wagerField = wagerObject.GetComponentInChildren<InputField>();
        wagerField.text = currentAddRedScore.ToString();


    }

    public void BlueWagerButtonClick()
    {
        isRed = false;
        wagerObject.SetActive(true);
        InputField wagerField = wagerObject.GetComponentInChildren<InputField>();
        wagerField.text = currentAddBlueScore.ToString();
    }

    //wager pannel

    public void ExitWagerButtonClick()
    {
        wagerObject.SetActive(false);
    }

    public void SetWagerButtonClick()
    {
        InputField wagerField = wagerObject.GetComponentInChildren<InputField>();

        if (isRed)
        {
            currentAddRedScore = System.Int32.Parse(wagerField.text);//set score
            GameObject.Find("RedAddButton").GetComponentInChildren<Text>().text = "+" + currentAddRedScore.ToString();
            GameObject.Find("RedSubtractButton").GetComponentInChildren<Text>().text = "-" + currentAddRedScore.ToString();
        }
        else
        {
            currentAddBlueScore = System.Int32.Parse(wagerField.text);//set score
            GameObject.Find("BlueAddButton").GetComponentInChildren<Text>().text = "+" + currentAddBlueScore.ToString();
            GameObject.Find("BlueSubtractButton").GetComponentInChildren<Text>().text = "-" + currentAddBlueScore.ToString();
        }

        wagerObject.SetActive(false);
    }

    public void AnswerQuestionButtonClick()
    {
        ////display either question or answer on the student view
        //public void ChangeDisplay()
        //{
        bool isAnswer;
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        if(obj.name == "AnswerButton")
        {
            isAnswer = true;
        }
        else
        {
            isAnswer = false;
        }
        //    GameObject object1 = obj.transform.GetChild(0).gameObject;
        //    Debug.Log(object1.GetComponent<Text>().text);

        //    displayPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = object1.GetComponent<Text>().text;

        //}

        qaGameAudienceObject.SendMessage("UpdateContent", isAnswer);
    }

}
