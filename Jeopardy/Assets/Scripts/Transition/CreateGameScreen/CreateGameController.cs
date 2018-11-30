using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class CreateGameController : MonoBehaviour
{
    private CreateGamePanelSwitch panelSwitch;
    private InputField categoryInput;
    private InputField questionInput;
    private InputField answerInput;
    private Toggle doubleToggle;

    public JQuestion CurrentEditingQuestion { get; set; }
    public JCategory CurrentEditingCategory { get; set; }

    public delegate void Callback();
    public Callback CallbackMethod;

    private void Start()
    {
        categoryInput = GameObject.Find("CategoryInputField").GetComponent<InputField>();
        questionInput = GameObject.Find("QuestionInputField").GetComponent<InputField>();
        answerInput   = GameObject.Find("AnswerInputField").GetComponent<InputField>();
        doubleToggle  = GameObject.Find("DailyDoubleToggle").GetComponent<Toggle>();
        panelSwitch = gameObject.GetComponent<CreateGamePanelSwitch>();
        LoadData();
    }

    void LoadData()
    {
        GameDataManager.InitDemo();  
        GameDataManager.LoadData();
        for (int i = 0; i < 10; i++)
        {
            GameObject.Find("RedTeamInputField" + i).GetComponent<InputField>().text = GameData.RedTeam[i];
            GameObject.Find("BlueTeamInputField" + i).GetComponent<InputField>().text = GameData.BlueTeam[i];
        }

        GameObject.Find("GameNameInputField").GetComponent<InputField>().text = GameData.GameName;
    }

    public void ExitCreateGameButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveGameButtonClick()
    {
        for (int i = 0; i < 10; i++)
        {
            GameData.RedTeam[i] = GameObject.Find("RedTeamInputField" + i).GetComponent<InputField>().text;
            GameData.BlueTeam[i] = GameObject.Find("BlueTeamInputField" + i).GetComponent<InputField>().text;
        }
        GameData.GameName = GameObject.Find("GameNameInputField").GetComponent<InputField>().text ;

        GameDataManager.SaveData();
    }

    public void CategoryButtonClick()
    {        
        if (CurrentEditingCategory.Category != "")
        {
            categoryInput.text = CurrentEditingCategory.Category;
        }
        panelSwitch.OpenEditCategoryPanel();
    }

   
    public void QuestionButtonClick()
    {
        if (CurrentEditingQuestion.Question != "")
        {
            questionInput.text = CurrentEditingQuestion.Question;
        }
        
        if (CurrentEditingQuestion.Answer != "")
        {
            answerInput.text = CurrentEditingQuestion.Answer;
        }
        
        doubleToggle.isOn = CurrentEditingQuestion.isDouble;
        panelSwitch.OpenEditQuestionPanel();
        
    }

    public void SaveQuestionButtonClick()
    {
        string questionText = questionInput.text;
        string answerText = answerInput.text;

        if (questionText != "" && answerText != "")
        {
            CurrentEditingQuestion.Question = questionText;
            CurrentEditingQuestion.Answer = answerText;
            CurrentEditingQuestion.Clue = "";
            CurrentEditingQuestion.isDouble = doubleToggle.isOn;
            CallbackMethod();
        }
        panelSwitch.CloseEditQuestionPanel();
    }

    public void SaveCategoryButtonClick()
    {
       
        string categoryText = categoryInput.text;
        if(categoryText != "")
        {
            Debug.Log("success");
            CurrentEditingCategory.Category = categoryInput.text;
            CallbackMethod();
        }
        panelSwitch.CloseEditCategoryPanel();
    }

}
