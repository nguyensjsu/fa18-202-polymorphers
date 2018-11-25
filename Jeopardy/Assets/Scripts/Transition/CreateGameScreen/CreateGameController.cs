﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateGameController : MonoBehaviour
{

    private GameObject teamsObject;
    private GameObject jeopardyObject;
    private GameObject doubleJeopardyObject;
    private GameObject finalJeopardyObject;

    private GameObject categoryEditPanel;
    private GameObject questionEditPanel;

    private bool isDailyDouble = true;

    private string cuttentCategoryName;

    // Use this for initialization
    void Start()
    {

        teamsObject = GameObject.Find("TeamsPanel");
        jeopardyObject = GameObject.Find("JeopardyPanel");
        doubleJeopardyObject = GameObject.Find("DoubleJeopardyPanel");
        finalJeopardyObject = GameObject.Find("FinalJeopardyPanel");

        categoryEditPanel = GameObject.Find("CategoryEditPanel");
        questionEditPanel = GameObject.Find("QuestionEditPanel");


        Transform temp_transform = jeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        temp_transform = finalJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        temp_transform = doubleJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        temp_transform = categoryEditPanel.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        temp_transform = questionEditPanel.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        GameObject toggleObj = GameObject.Find("DailyDoubleToggle");
        Toggle togle = toggleObj.GetComponent<Toggle>();
        togle.onValueChanged.AddListener((bool value) => OnToggleClick(togle, value));

        teamsObject.SetActive(true);
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);


        categoryEditPanel.SetActive(false);
        questionEditPanel.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitCreateGameButtonClick()
    {
        /*
         * (David)
         * Prompt Save Game
         */

        SceneManager.LoadScene("MainMenu");
    }

    public void SaveGameButtonClick()
    {
        //get game name
        string gameName = GameObject.Find("NameOfGameField").GetComponent<InputField>().text;
        //get red team name
        string redTeam1 = GameObject.Find("RedTeamInputField").GetComponent<InputField>().text;

        //get blue team name
        string blueTeam1 = GameObject.Find("BlueTeamInputField").GetComponent<InputField>().text;


        Debug.Log(gameName);
        Debug.Log(redTeam1);
        Debug.Log(blueTeam1);


        //GameData.GameDataManager.SaveData();
    }

    public void TeamsButtonClick()
    {
        teamsObject.SetActive(true);
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
    }

    public void JeopardyButtonClick()
    {
        teamsObject.SetActive(false);
        jeopardyObject.SetActive(true);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
    }

    public void DoubleJeopardyClick()
    {
        teamsObject.SetActive(false);
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(true);
        finalJeopardyObject.SetActive(false);
    }

    public void FinalJeopardyClick()
    {
        teamsObject.SetActive(false);
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(true);

        Transform temp_transform = finalJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

    }

    public void CategoryButtonClick()
    {
        cuttentCategoryName = EventSystem.current.currentSelectedGameObject.name;


        Transform temp_transform = categoryEditPanel.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        categoryEditPanel.SetActive(true);

        //read category imformation
        InputField txt_Input = GameObject.Find("InputField").GetComponent<InputField>();

        string lastIndex = cuttentCategoryName.Substring((cuttentCategoryName.Length) - 1, 1);
        int n = System.Int32.Parse(lastIndex);

        string ObjectsText = GameData.GameData.Category[n];
        if(!(ObjectsText == ""))
        {
            txt_Input.text = ObjectsText;
        }

    }

    public void QuestionButtonClick()
    {


        Transform temp_transform = questionEditPanel.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        questionEditPanel.SetActive(true);

        InputField question_Input = GameObject.FindGameObjectWithTag("Question").GetComponent<InputField>();
        InputField answer_Input = GameObject.FindGameObjectWithTag("Answer").GetComponent<InputField>();
        GameData.JQuestion s = GameData.GameData.Question[0][0];        
        if (!(s.Question == ""))
        {
            question_Input.text = s.Question;
        }
        if (!(s.Answer == ""))
        {
            answer_Input.text = s.Answer;
        }

    }

    // all methods of questionEditPanel
    public void ExitQuestionPanelClick()
    {
        questionEditPanel.SetActive(false);

    }

    public void OnToggleClick(Toggle toggle, bool value)
    {
        isDailyDouble = value;
    }

    public void SaveQuestionButtonClick()
    {
        InputField question_Input = GameObject.FindGameObjectWithTag("Question").GetComponent<InputField>();
        InputField answer_Input = GameObject.FindGameObjectWithTag("Answer").GetComponent<InputField>();
        string questionText = question_Input.text;
        string answerText = answer_Input.text;

        if (questionText == "" && answerText == "")
        {
            Debug.Log("Please input text");
        }
        else
        {

            //test code

            //GameData.JQuestion s = GameData.GameData.Question[0][0];
            //s.Question = questionText;
            //s.Answer = answerText;
            //s.Value = 100;
            //s.Clue = "";
            //s.isDouble = false;

            //GameData.JQuestion m = GameData.GameData.Question[0][0];
            //Debug.Log(s.Question);
            //Debug.Log(m.Question);


            GameData.JQuestion s;
            s.Question = questionText;
            s.Answer = answerText;
            s.Value = 100;
            s.Clue = "";
            s.isDouble = isDailyDouble;
            GameData.GameData.Question[0][0] = s;

            questionEditPanel.SetActive(false);

        }
    }

    // all methods of categotyEnditPanel

    public void ExitCategoryPanelClick()
    {
        categoryEditPanel.SetActive(false);

    }

    public void SaveCategoryButtonClick()
    {
        InputField txt_Input = GameObject.Find("InputField").GetComponent<InputField>();
        string ObjectsText = txt_Input.text;
        if(ObjectsText == "")
        {
            Debug.Log("Please input text");
        }
        else
        {
            string lastIndex = cuttentCategoryName.Substring((cuttentCategoryName.Length) - 1, 1);
            int n = System.Int32.Parse(lastIndex);

            Text text = GameObject.Find(cuttentCategoryName).GetComponentInChildren<Text>();
            text.text = ObjectsText;

            // save data 
            GameData.GameData.Category[n] = ObjectsText;
            categoryEditPanel.SetActive(false);
        }
    }

}
