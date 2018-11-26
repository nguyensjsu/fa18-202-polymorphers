﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class HostGameController : MonoBehaviour {

    private GameObject jeopardyObject;
    private GameObject doubleJeopardyObject;
    private GameObject finalJeopardyObject;

    private GameObject setScoreOverlay;
    private InputField scoreInput;

    private GameObject audienceObject;

    private string currentButtonName;

    private GameObject qaGameHostObject;


    private bool isRed;

    public int TotalTime = 5;

    // Use this for initialization
    void Start()
    {
        jeopardyObject = GameObject.Find("JeopardyPanel");
        doubleJeopardyObject = GameObject.Find("DoubleJeopardyPanel");
        finalJeopardyObject = GameObject.Find("FinalJeopardyPanel");

        setScoreOverlay = GameObject.Find("SetScoreOverlay");
        scoreInput = GameObject.Find("SetScoreOverlay").GetComponentInChildren<InputField>();

        audienceObject = GameObject.Find("GameAudienceScreen");

        qaGameHostObject = GameObject.Find("QAGameHostScreen");


        Transform temp_transform = jeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        temp_transform = finalJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        temp_transform = doubleJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        jeopardyObject.SetActive(true);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
    }


    // Update is called once per frame
    void Update () {
   

	}
    
    public void JeopardyButtonClick()
    {
        jeopardyObject.SetActive(true);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
        audienceObject.SendMessage("changePanel", "0");
    }

    public void DoubleJeopardyClick()
    {

        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(true);
        finalJeopardyObject.SetActive(false);
        audienceObject.SendMessage("changePanel", "1");

    }

    public void FinalJeopardyClick()
    {


        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(true);
        audienceObject.SendMessage("changePanel", "2");

    }

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void RedButtonClick()
    {
        Transform temp_transform = setScoreOverlay.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        setScoreOverlay.SetActive(true);
        isRed = true;

    }

    public void ExitScoreScreenButtonClick()
    {
        setScoreOverlay.SetActive(false);
    }

    public void SetScoreButtonClick()
    {
        string score = scoreInput.text;
        if(isRed)
        {
            GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text = score;
        }
        else
        {
            GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text = score;
        }


        object[] tempStorage = new object[2];
        string a;
        if(isRed)
        {
            a = "1";
        }else
        {
            a = "0";
        }
        tempStorage[0] = a;
        tempStorage[1] = score;
        audienceObject.SendMessage("setScore", tempStorage);

        setScoreOverlay.SetActive(false);

    }

    public void BlueButtonClick()
    {
        Transform temp_transform = setScoreOverlay.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        setScoreOverlay.SetActive(true);
        isRed = false;
    }

    public void QuestionButtonClick()
    {

        EventSystem.current.currentSelectedGameObject.SetActive(false);

        Transform temp_transform = qaGameHostObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, 0f, temp_transform.position.z);

        qaGameHostObject.SetActive(true);

        currentButtonName = EventSystem.current.currentSelectedGameObject.name;
        //string lineIndex = currentButtonName.Substring((currentButtonName.Length) - 2, 1);
        //int line = System.Int32.Parse(lineIndex);
        //string rowIndex = currentButtonName.Substring((currentButtonName.Length) - 1, 1);
        //int row = System.Int32.Parse(rowIndex);

        audienceObject.SendMessage("changePanel", "3");

        string index = currentButtonName.Substring(currentButtonName.Length-2, 2);
        Debug.Log(index);
        audienceObject.SendMessage("dispearButton", index);
    }

    //teacher question pannel

    public void ExitQAHostButtonClick()
    {
        qaGameHostObject.SetActive(false);
        audienceObject.SendMessage("changePanel", "4");
    }

    public void StartButtonClick()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (TotalTime >= 0)
        {

            GameObject.Find("ClockText").GetComponent<Text>().text = TotalTime.ToString();
            audienceObject.SendMessage("SetAudienceTime", TotalTime.ToString());
            yield return new WaitForSeconds(1);
            Debug.Log(TotalTime);
            TotalTime--;
        }
        if(TotalTime == 0)
        {
            StopAllCoroutines();
            TotalTime = 5;
        }
    }


}
