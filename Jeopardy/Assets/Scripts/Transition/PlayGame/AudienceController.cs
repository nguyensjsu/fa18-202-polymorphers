﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class AudienceController : MonoBehaviour {

    private Text redText;
    private Text blueText;

    private GameObject qaAudienceObject;

    private GameObject jeopardyObject;
    private GameObject doubleJeopardyObject;
    private GameObject finalJeopardyObject;




    // Use this for initialization
    void Start () {
        redText = GameObject.Find("Team1Score").GetComponent<Text>();
        blueText = GameObject.Find("Team2Score").GetComponent<Text>();


        jeopardyObject = GameObject.Find("AudienceJeopardyPanel");
        doubleJeopardyObject = GameObject.Find("AudienceDoubleJeopardyPanel");
        finalJeopardyObject = GameObject.Find("AudienceFinalJeopardyPanel");

        qaAudienceObject = GameObject.Find("QAGameAudienceScreen");

        Transform temp_transform = jeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        temp_transform = finalJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        temp_transform = doubleJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        temp_transform = qaAudienceObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, 1024, temp_transform.position.z);

        //jeopardyObject.SetActive(true);
        //doubleJeopardyObject.SetActive(false);
        //finalJeopardyObject.SetActive(false);
        //qaAudienceObject.SetActive(false);

        jeopardyObject.SetActive(true);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
        qaAudienceObject.SetActive(false);

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

    public void SetAudienceTime(string time)
    {
        GameObject.Find("AudienceClockText").GetComponent<Text>().text = time;
    }

    public void dispearButton(string index)
    {
        string str = "AudienceButton" + index;
        Debug.Log(str);
        GameObject.Find(str).SetActive(false);
    }

    public void changePanel(string panel)
    {
        if(panel == "0")
        {
            jeopardyObject.SetActive(true);
            doubleJeopardyObject.SetActive(false);
            finalJeopardyObject.SetActive(false);
        }
        else if(panel == "1")
        {
            jeopardyObject.SetActive(false);
            doubleJeopardyObject.SetActive(true);
            finalJeopardyObject.SetActive(false);
        }
        else if(panel == "2")
        {
            jeopardyObject.SetActive(false);
            doubleJeopardyObject.SetActive(false);
            finalJeopardyObject.SetActive(true);

        }else if(panel == "3")
        {
            //jeopardyObject.SetActive(false);
            //doubleJeopardyObject.SetActive(false);
            //finalJeopardyObject.SetActive(false);
            qaAudienceObject.SetActive(true);
        }else
        {
            qaAudienceObject.SetActive(false);

        }
    }
}