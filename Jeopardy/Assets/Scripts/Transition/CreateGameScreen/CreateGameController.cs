//
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//
//using System.IO;
//
//
//public class CreateGameController : MonoBehaviour
//{
//
//    private GameObject teamsObject;
//    private GameObject jeopardyObject;
//    private GameObject doubleJeopardyObject;
//    private GameObject finalJeopardyObject;
//
//    private GameObject categoryEditPanel;
//    private GameObject questionEditPanel;
//    private GameObject loadImagePanel;
//
//    private bool isDailyDouble = true;
//
//    private string currentCategoryName;
//    private string currentButtonName;
//
//    public Button teamsButton;
//    public Button jeopardyButton;
//    public Button doubleJeopardyButton;
//    public Button finalJeopardyButton;
//
//
//
//    private string tempCategoryString;
//
//    public GameObject loadImageCanvas;
//    public GameObject loadImageButton;
//
//    private string imagePath;
//    private int buttonNameImageLoadLine;
//    private int buttonNameImageLoadRow;
//
//
//
//
//  
//    // Use this for initialization
//    void Start()
//    {
//
//      
//
//
//        teamsObject = GameObject.Find("TeamsPanel");
//        jeopardyObject = GameObject.Find("JeopardyPanel");
//        doubleJeopardyObject = GameObject.Find("DoubleJeopardyPanel");
//        finalJeopardyObject = GameObject.Find("FinalJeopardyPanel");
//
//        categoryEditPanel = GameObject.Find("CategoryEditPanel");
//        questionEditPanel = GameObject.Find("QuestionEditPanel");
//        loadImagePanel = GameObject.Find("LoadImagePanel");
//
//        Transform temp_transform = jeopardyObject.GetComponent<Transform>();
//        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
//
//        temp_transform = finalJeopardyObject.GetComponent<Transform>();
//        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
//        temp_transform = doubleJeopardyObject.GetComponent<Transform>();
//        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
//
//        temp_transform = categoryEditPanel.GetComponent<Transform>();
//        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
//        temp_transform = questionEditPanel.GetComponent<Transform>();
//        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
//
//        GameObject toggleObj = GameObject.Find("DailyDoubleToggle");
//        Toggle togle = toggleObj.GetComponent<Toggle>();
//        togle.onValueChanged.AddListener((bool value) => OnToggleClick(togle, value));
//
//        teamsObject.SetActive(true);
//        jeopardyObject.SetActive(false);
//        doubleJeopardyObject.SetActive(false);
//        finalJeopardyObject.SetActive(false);
//        categoryEditPanel.SetActive(false);
//        questionEditPanel.SetActive(false);
//
//        GameDataManager.LoadData();
//    }
//
//
//    // Update is called once per frame
//    void Update()
//    {
//
//    }
//
//    public void ExitCreateGameButtonClick()
//    {
//        /*
//         * (David)
//         * Prompt Save Game
//         */
//
//        SceneManager.LoadScene("MainMenu");
//    }
//
//    public void SaveGameButtonClick()
//    {
//        //get game name
//        string gameName = GameObject.Find("NameOfGameField").GetComponent<InputField>().text;
//
//        Debug.Log(gameName);
//
//        string[] redTeam = new string[10];
//        string[] blueTeam = new string[10]; ;
////        for (int i = 0; i < 10; i++)
////        {
////            redTeam[i] = GameObject.Find("RedTeamInputField" + i).GetComponent<InputField>().text;
////            blueTeam[i] = GameObject.Find("BlueTeamInputField" + i).GetComponent<InputField>().text;
////            Debug.Log("redTeam" + i + ": " + redTeam[i]);
////            Debug.Log("blueTeam" + i + ": " + blueTeam[i]);
////
////        }
//
//        GameDataManager.SaveData();
//    }
//
//    private void ChangeButtonColorAndText(Button button, Color buttonColor, Color textColor)
//    {
//        ColorBlock cb = button.GetComponentInChildren<Button>().colors;
//        cb.normalColor = cb.highlightedColor = buttonColor;
//        button.GetComponentInChildren<Button>().colors = cb;
//        button.GetComponentInChildren<Text>().color = textColor;
//    }
//
//    public void TeamsButtonClick()
//    {
//        ChangeButtonColorAndText(teamsButton, Color.black, Color.white);
//        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);
//        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);
//        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);
//
//        teamsObject.SetActive(true);
//        jeopardyObject.SetActive(false);
//        doubleJeopardyObject.SetActive(false);
//        finalJeopardyObject.SetActive(false);
//    }
//
//    public void JeopardyButtonClick()
//    {
//        ChangeButtonColorAndText(teamsButton, Color.white, Color.black);
//        ChangeButtonColorAndText(jeopardyButton, Color.black, Color.white);
//        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);
//        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);
//
//        teamsObject.SetActive(false);
//        jeopardyObject.SetActive(true);
//        doubleJeopardyObject.SetActive(false);
//        finalJeopardyObject.SetActive(false);
//    }
//
//    public void DoubleJeopardyClick()
//    {
//        ChangeButtonColorAndText(teamsButton, Color.white, Color.black);
//        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);
//        ChangeButtonColorAndText(doubleJeopardyButton, Color.black, Color.white);
//        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);
//
//        teamsObject.SetActive(false);
//        jeopardyObject.SetActive(false);
//        doubleJeopardyObject.SetActive(true);
//        finalJeopardyObject.SetActive(false);
//    }
//
//    public void FinalJeopardyClick()
//    {
//        ChangeButtonColorAndText(teamsButton, Color.white, Color.black);
//        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);
//        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);
//        ChangeButtonColorAndText(finalJeopardyButton, Color.black, Color.white);
//
//        teamsObject.SetActive(false);
//        jeopardyObject.SetActive(false);
//        doubleJeopardyObject.SetActive(false);
//        finalJeopardyObject.SetActive(true);
//
//        Transform temp_transform = finalJeopardyObject.GetComponent<Transform>();
//        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
//
//    }
//
//    public void CategoryButtonClick()
//    {
//        currentCategoryName = EventSystem.current.currentSelectedGameObject.name;
//
//
//        Transform temp_transform = categoryEditPanel.GetComponent<Transform>();
//        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
//
//        categoryEditPanel.SetActive(true);
//
//        //read category imformation
//        InputField txt_Input = GameObject.Find("InputField").GetComponent<InputField>();
//
//        Text text = GameObject.Find(currentCategoryName).GetComponentInChildren<Text>();
//        tempCategoryString = text.text;
//        Debug.Log(tempCategoryString);
//
//        string index = currentCategoryName.Substring((currentCategoryName.Length) - 1, 1);
//        int n = System.Int32.Parse(index);
//
//        Debug.Log(n);
//        string ObjectsText = GameData.Category[n];
//        Debug.Log(ObjectsText);
//        txt_Input.text = ObjectsText;
//    }
//
//   
//    public void QuestionButtonClick()
//    {
//        currentButtonName = EventSystem.current.currentSelectedGameObject.name;
//
//
//        Transform temp_transform = questionEditPanel.GetComponent<Transform>();
//        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
//
//        questionEditPanel.SetActive(true);
//
//        InputField question_Input = GameObject.FindGameObjectWithTag("Question").GetComponent<InputField>();
//        InputField answer_Input = GameObject.FindGameObjectWithTag("Answer").GetComponent<InputField>();
//
//        string lineIndex = currentButtonName.Substring((currentButtonName.Length) - 2, 1);
//        int line = System.Int32.Parse(lineIndex);
//        Debug.Log(line);
//
//        string rowIndex = currentButtonName.Substring((currentButtonName.Length) - 1, 1);
//        int row = System.Int32.Parse(rowIndex);
//        Debug.Log(row);
//
//        /*
//         * David-
//         * These coordinates need to be saved to create an image for the correct
//         * question.
//         */
//        buttonNameImageLoadLine = line;
//        buttonNameImageLoadRow = row;
//
//        JQuestion s;
//
//        if (currentButtonName[6] == 'D'){
//           s = GameData.Question[line][row];
//        }else{
//           s = GameData.Question[line][row];
//        }
//          
//        if (!(s.ImgPath == null) && !(s.ImgPath == ""))
//        {
//            Debug.Log("path" + s.ImgPath);
//            AddImageToQuestion(s.ImgPath);
//        }
//        else
//        {
//            ResetImageToQuestion();
//
//            if (!(s.Question == ""))
//            {
//                question_Input.text = s.Question;
//            }
//            if (!(s.Answer == ""))
//            {
//                answer_Input.text = s.Answer;
//            }
//        }
//    }
//
//    public void LoadImageButtonClick()
//    {
//        Transform temp_transform = loadImagePanel.GetComponent<Transform>();
//        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
//
//        loadImagePanel.SetActive(true);
//
//        LoadImagesFromLocal();
//    }
//
//    // all methods of questionEditPanel
//    public void ExitQuestionPanelClick()
//    {
//        questionEditPanel.SetActive(false);
//
//    }
//
//    public void OnToggleClick(Toggle toggle, bool value)
//    {
//        isDailyDouble = value;
//    }
//
//    public void SaveQuestionButtonClick()
//    {
//        InputField question_Input = GameObject.FindGameObjectWithTag("Question").GetComponent<InputField>();
//        InputField answer_Input = GameObject.FindGameObjectWithTag("Answer").GetComponent<InputField>();
//        string questionText = question_Input.text;
//        string answerText = answer_Input.text;
//
//        if (questionText == "" && answerText == "")
//        {
//            Debug.Log("Please input text");
//        }
//        else
//        {
//
//            string lineIndex = currentButtonName.Substring((currentButtonName.Length) - 2, 1);
//            int line = System.Int32.Parse(lineIndex);
//
//            string rowIndex = currentButtonName.Substring((currentButtonName.Length) - 1, 1);
//            int row = System.Int32.Parse(rowIndex);
//
//            JQuestion s = GameData.Question[line][row];
//            s.Question = questionText;
//            s.Answer = answerText;
//            s.Value = 100;
//            s.Clue = "";
//            s.isDouble = isDailyDouble;
//
//            questionEditPanel.SetActive(false);
//
//        }
//    }
//
//    public void ExitCategoryPanelClick()
//    {
//        categoryEditPanel.SetActive(false);
//
//        string index = currentCategoryName.Substring((currentCategoryName.Length) - 1, 1);
//        int n = System.Int32.Parse(index);
//
//        Text text = GameObject.Find(currentCategoryName).GetComponentInChildren<Text>();
//        text.text = tempCategoryString;
//
//
//    }
//
//    public void SaveCategoryButtonClick()
//    {
//        InputField txt_Input = GameObject.Find("InputField").GetComponent<InputField>();
//        string ObjectsText = txt_Input.text;
//        if(ObjectsText == "")
//        {
//            Debug.Log("Please input text");
//        }
//        else
//        {
//            string index = currentCategoryName.Substring((currentCategoryName.Length) - 1, 1);
//            int n = System.Int32.Parse(index);
//
//            Text text = GameObject.Find(currentCategoryName).GetComponentInChildren<Text>();
//            text.text = ObjectsText;
//
//            // save data 
//            GameData.Category[n] = ObjectsText;
//            txt_Input.text = "";
//            categoryEditPanel.SetActive(false);
//        }
//    }
//
//
//    /*
//     * This is called after the loadimage panel is activated
//     * And fills it with buttons representing images from local
//     */
//    private void LoadImagesFromLocal()
//    {
//
//
//
//        string thepath = Path.Combine(Application.persistentDataPath, "images");
//
//        DirectoryInfo d = new DirectoryInfo(thepath);
//
//        FileInfo[] Files = d.GetFiles("*.png");
//
//        foreach (Transform child in loadImagePanel.transform.Find("Panel").transform.Find("ImagesPanel")){
//            Debug.Log(child.gameObject.name);
//            Destroy(child.gameObject);
//        }
//
//
//
//        foreach (FileInfo file in Files)
//        {
//            imagePath = Path.Combine(thepath, file.Name);
//
//            Debug.Log(imagePath);
//            CreateButtonWithImage(imagePath);
//            
//
//        }
//
//
//    }
//
//    /*
//     * Called when user clicks on image to add to an answer
//     * 
//     * 
//     */
//
//    public void ImageClick()
//    {
//        GameObject currentButton = EventSystem.current.currentSelectedGameObject;
//        string imgPath = currentButton.GetComponentInChildren<Text>().text;
//
//        Debug.Log("Image click");
//
//        loadImagePanel.SetActive(false);
//
//        JQuestion s;
//
//        if (currentButtonName[6] == 'D')
//        {
//            //Jinzhou needs to figure out how to save both Double Jeopardy and Jeopardy
//            s = GameData.Question[buttonNameImageLoadLine][buttonNameImageLoadRow];
//        }
//        else
//        {
//            s = GameData.Question[buttonNameImageLoadLine][buttonNameImageLoadRow];
//        }
//        AddImageToQuestion(imgPath);
//
//    }
//
//    private void AddImageToQuestion(string imgPath)
//    {
//        GameObject question = GameObject.FindGameObjectWithTag("Question");//Actually the answer.
//        question.GetComponent<Image>().sprite = GetSprite(imgPath);
//        question.GetComponent<Image>().color = Color.white;
//        question.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "";
//    }
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//    /*
//     * Given path to image file
//     * Create a new texture
//     * Creates a new button
//     * Applies the texture to the button
//     * Write the path to the button's text
//     * 
//
//    */
//
//    private void CreateButtonWithImage(string path){
//        byte[] fileData;
//        Texture2D tex = null;
//        if (File.Exists(path))
//        {
//            fileData = File.ReadAllBytes(path);
//            tex = new Texture2D(50, 50);
//            tex.LoadImage(fileData);
//
//            GameObject newButton = Instantiate(loadImageButton);
//            newButton.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
//            newButton.transform.SetParent(loadImageCanvas.transform, false);
//
//            newButton.GetComponentInChildren<Text>().text = path; //GetComponent<Text>().text = path;
//            Color col = newButton.GetComponentInChildren<Text>().color;
//            col.a = 0.0f;
//            newButton.GetComponentInChildren<Text>().color = col;
//
//            newButton.GetComponent<Button>().onClick.AddListener(ImageClick);
//
//           
//        }
//        else
//        {
//            Debug.Log(path);
//        }
//    }
//
//    private Sprite GetSprite(string path)
//    {
//        byte[] fileData;
//        Texture2D tex = null;
//        if (File.Exists(path))
//        {
//            fileData = File.ReadAllBytes(path);
//            tex = new Texture2D(50, 50);
//            tex.LoadImage(fileData);
//
//            return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
//
//        }
//
//        return null;
//    }
//
//    private void ResetImageToQuestion(){
//        GameObject question = GameObject.FindGameObjectWithTag("Question");//Actually the answer.
//        question.GetComponent<Image>().sprite = null;
//        question.GetComponent<Image>().color = Color.blue;
//        question.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "ENTER TEXT...";
//
//    }
//
//    
//
//
//
//}
//=======

using System;
using System.Collections;
using System.Collections.Generic;
 using System.IO;
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
    private InputField valueInput;
    private InputField gameNameInput;
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
        valueInput   = GameObject.Find("ValueInputField").GetComponent<InputField>();
        gameNameInput   = GameObject.Find("NameInputField").GetComponent<InputField>();
        doubleToggle  = GameObject.Find("DailyDoubleToggle").GetComponent<Toggle>();
        panelSwitch = gameObject.GetComponent<CreateGamePanelSwitch>();
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
        GameData.GameName = gameNameInput.GetComponent<InputField>().text ;
        GameDataManager.SaveData();
        SceneManager.LoadScene("MainMenu");
    }

    public void CategoryButtonClick()
    {        
        if (CurrentEditingCategory.Category != "")
        {
            categoryInput.text = CurrentEditingCategory.Category;
        }
        panelSwitch.OpenPanel("CategoryEdit");
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
        
        if (CurrentEditingQuestion.Value != 0)
        {
            valueInput.text = CurrentEditingQuestion.Value.ToString();
        }
        
        doubleToggle.isOn = CurrentEditingQuestion.isDouble;
        panelSwitch.OpenPanel("QuestionEdit");
        
    }

    public void SaveQuestionButtonClick()
    {
        if (answerInput.text != "" && questionInput.text != "")
        {
            CurrentEditingQuestion.Question = answerInput.text;
            CurrentEditingQuestion.Answer = questionInput.text;
            CurrentEditingQuestion.Value = Convert.ToInt32(valueInput.text);
            CurrentEditingQuestion.Clue = "";
            CurrentEditingQuestion.isDouble = doubleToggle.isOn;
            CallbackMethod();
        }
        panelSwitch.ClosePanel("QuestionEdit");
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
        panelSwitch.ClosePanel("CategoryEdit");
    }

    public void InitGame()
    {
        GameDataManager.Init();
        LoadData();
    }

    public void LoadGame(FileInfo file)
    {
        GameDataManager.LoadData(file);
        LoadData();
    }
    
    void LoadData()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject.Find("RedTeamInputField" + i).GetComponent<InputField>().text = GameData.RedTeam[i];
            GameObject.Find("BlueTeamInputField" + i).GetComponent<InputField>().text = GameData.BlueTeam[i];
            Debug.Log(GameData.RedTeam[i]);
        }
        gameNameInput.GetComponent<InputField>().text = GameData.GameName;
    }

}
