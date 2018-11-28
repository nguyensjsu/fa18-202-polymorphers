using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI; 

public class CreateGameController : MonoBehaviour
{

    private GameObject jeopardyObject;
    private GameObject doubleJeopardyObject;
    private GameObject finalJeopardyObject;

    private GameObject categoryEditPanel;
    private GameObject questionEditPanel;

    private bool isDailyDouble = true; 

    // Use this for initialization
    void Start()
    {

        jeopardyObject = GameObject.Find("JeopardyPanel");
        doubleJeopardyObject = GameObject.Find("DoubleJeopardyPanel");
        finalJeopardyObject = GameObject.Find("FinalJeopardyPanel");

        categoryEditPanel = GameObject.Find("CategoryEditPanel");
        questionEditPanel = GameObject.Find("QuestionEditPanel");

        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);

        categoryEditPanel.SetActive(false);


        GameObject toggleObj = GameObject.Find("Toggle");
        Debug.Log(toggleObj);
        Toggle togle = toggleObj.GetComponent<Toggle>();
        togle.onValueChanged.AddListener((bool value) => OnToggleClick(togle, value));

        questionEditPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitCreateGameButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveGameButtonClick()
    {
        // save game;
        GameDataManager.SaveData();
    }

    public void JeopardyButtonClick()
    {
        jeopardyObject.SetActive(true);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
    }

    public void DoubleJeopardyClick()
    {
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(true);
        finalJeopardyObject.SetActive(false);


        Transform temp_transform = doubleJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
    }

    public void FinalJeopardyClick()
    {
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(true);

        Transform temp_transform = finalJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

    }

    public void CategoryButtonClick()
    {
        Transform temp_transform = categoryEditPanel.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        categoryEditPanel.SetActive(true);

        //read category imformation
        InputField txt_Input = GameObject.Find("InputField").GetComponent<InputField>();

        string ObjectsText = GameData.Category[0];
        if(!(ObjectsText == ""))
        {
            txt_Input.text = ObjectsText;
        }

    }

    public void OneHunderdButtonClick()
    {
        Transform temp_transform = questionEditPanel.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        questionEditPanel.SetActive(true);

        InputField question_Input = GameObject.FindGameObjectWithTag("Question").GetComponent<InputField>();
        InputField answer_Input = GameObject.FindGameObjectWithTag("Answer").GetComponent<InputField>();
        JQuestion s = GameData.Question[0][0];        
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


//            JQuestion s;
//            s.Question = questionText;
//            s.Answer = answerText;
//            s.Value = 100;
//            s.Clue = "";
//            s.isDouble = isDailyDouble;
//            GameData.Question[0][0] = s;
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
            // save data 
            GameData.Category[0] = ObjectsText;
            Debug.Log(GameData.Category[0]);
            categoryEditPanel.SetActive(false);
        }
    }

}
