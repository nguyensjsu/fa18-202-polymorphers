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
    }

    public void OneHunderdButtonClick()
    {
        Transform temp_transform = questionEditPanel.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        questionEditPanel.SetActive(true);

    }

    // all methods of questionEditPanel
    public void ExitQuestionPanelClick()
    {
        questionEditPanel.SetActive(false);

    }

    public void SaveQuestionButtonClick()
    {
        InputField question_Input = GameObject.FindGameObjectsWithTag("Question")[0].GetComponent<InputField>();
        InputField answer_Input = GameObject.FindGameObjectsWithTag("Answer")[0].GetComponent<InputField>();
        string questionText = txt_Input.text;
        string answerText = txt_Input.text;

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
            GameData.GameData.Category[0] = ObjectsText;
            Debug.Log(GameData.GameData.Category[0]);
            categoryEditPanel.SetActive(false);
        }
    }

}
