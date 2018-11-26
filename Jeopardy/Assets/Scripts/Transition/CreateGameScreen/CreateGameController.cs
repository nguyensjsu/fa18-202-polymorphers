using System.Collections;
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

    private string currentCategoryName;
    private string currentButtonName;

    public Button teamsButton;
    public Button jeopardyButton;
    public Button doubleJeopardyButton;
    public Button finalJeopardyButton;

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

    private void ChangeButtonColorAndText(Button button, Color buttonColor, Color textColor)
    {
        ColorBlock cb = button.GetComponentInChildren<Button>().colors;
        cb.normalColor = cb.highlightedColor = buttonColor;
        button.GetComponentInChildren<Button>().colors = cb;
        button.GetComponentInChildren<Text>().color = textColor;
    }

    public void TeamsButtonClick()
    {
        ChangeButtonColorAndText(teamsButton, Color.black, Color.white);
        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);
        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);
        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);

        teamsObject.SetActive(true);
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
    }

    public void JeopardyButtonClick()
    {
        ChangeButtonColorAndText(teamsButton, Color.white, Color.black);
        ChangeButtonColorAndText(jeopardyButton, Color.black, Color.white);
        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);
        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);

        teamsObject.SetActive(false);
        jeopardyObject.SetActive(true);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
    }

    public void DoubleJeopardyClick()
    {
        ChangeButtonColorAndText(teamsButton, Color.white, Color.black);
        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);
        ChangeButtonColorAndText(doubleJeopardyButton, Color.black, Color.white);
        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);

        teamsObject.SetActive(false);
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(true);
        finalJeopardyObject.SetActive(false);
    }

    public void FinalJeopardyClick()
    {
        ChangeButtonColorAndText(teamsButton, Color.white, Color.black);
        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);
        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);
        ChangeButtonColorAndText(finalJeopardyButton, Color.black, Color.white);

        teamsObject.SetActive(false);
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(true);

        Transform temp_transform = finalJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

    }

    public void CategoryButtonClick()
    {
        currentCategoryName = EventSystem.current.currentSelectedGameObject.name;


        Transform temp_transform = categoryEditPanel.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        categoryEditPanel.SetActive(true);

        //read category imformation
        InputField txt_Input = GameObject.Find("InputField").GetComponent<InputField>();

        string index = currentCategoryName.Substring((currentCategoryName.Length) - 1, 1);
        int n = System.Int32.Parse(index);

        string ObjectsText = GameData.GameData.Category[n];

        if(!(ObjectsText == ""))
        {
            txt_Input.text = ObjectsText;
        }

    }

    public void QuestionButtonClick()
    {
        currentButtonName = EventSystem.current.currentSelectedGameObject.name;


        Transform temp_transform = questionEditPanel.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        questionEditPanel.SetActive(true);

        InputField question_Input = GameObject.FindGameObjectWithTag("Question").GetComponent<InputField>();
        InputField answer_Input = GameObject.FindGameObjectWithTag("Answer").GetComponent<InputField>();

        string lineIndex = currentButtonName.Substring((currentButtonName.Length) - 2, 1);
        int line = System.Int32.Parse(lineIndex);
        Debug.Log(line);

        string rowIndex = currentButtonName.Substring((currentButtonName.Length) - 1, 1);
        int row = System.Int32.Parse(rowIndex);
        Debug.Log(row);


        GameData.JQuestion s = GameData.GameData.Question[line][row];        
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

            string lineIndex = currentButtonName.Substring((currentButtonName.Length) - 2, 1);
            int line = System.Int32.Parse(lineIndex);

            string rowIndex = currentButtonName.Substring((currentButtonName.Length) - 1, 1);
            int row = System.Int32.Parse(rowIndex);


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
            GameData.GameData.Question[line][row] = s;

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
            string index = currentCategoryName.Substring((currentCategoryName.Length) - 1, 1);
            int n = System.Int32.Parse(index);

            Text text = GameObject.Find(currentCategoryName).GetComponentInChildren<Text>();
            text.text = ObjectsText;

            // save data 
            GameData.GameData.Category[n] = ObjectsText;
            categoryEditPanel.SetActive(false);
        }
    }

}
