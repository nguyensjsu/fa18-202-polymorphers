using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.UI;using UnityEngine.SceneManagement;using UnityEngine.EventSystems;public class HostGameController : MonoBehaviour {    //question panel    private GameObject jeopardyObject;    private GameObject doubleJeopardyObject;    private GameObject finalJeopardyObject;    //set teamscore panel     private GameObject setScoreOverlay;    //select team panel    private GameObject selectTeamObject;    //the question detail of teacher
    private GameObject qaGameHostObject;
    //set wager panel
    private GameObject wagerObject;
    //audience panel     send message to the object
    private GameObject audienceObject;

    private InputField scoreInput;
    public Button jeopardyButton;    public Button doubleJeopardyButton;    public Button finalJeopardyButton;    private string currentButtonName;
    private string[] category;    private int TotalTime; //Countdown


    private bool isRed; //change team score and change team wager    //set team information
    private int currentRedIndex;
    private int currentBlueIndex;
    private string[] redTeam;    private string[] blueTeam;    private int temporaryRedIndex;
    private int temporaryBlueIndex;    //the question detail of teacher. set wager
    private int redButtonScore;    private int blueButtonScore;    private int currentRedScore;    private int currentBlueScore;

    // Use this for initialization
    void Start()    {        jeopardyObject = GameObject.Find("JeopardyPanel");        doubleJeopardyObject = GameObject.Find("DoubleJeopardyPanel");        finalJeopardyObject = GameObject.Find("FinalJeopardyPanel");        setScoreOverlay = GameObject.Find("SetScoreOverlay");        selectTeamObject = GameObject.Find("ChooseTeamsOverlay");        audienceObject = GameObject.Find("GameAudienceScreen");        qaGameHostObject = GameObject.Find("QAGameHostScreen");
        wagerObject = GameObject.Find("SetWagerOverlay");
        scoreInput = setScoreOverlay.GetComponentInChildren<InputField>();


        Transform temp_transform = jeopardyObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);        temp_transform = finalJeopardyObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);        temp_transform = doubleJeopardyObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        temp_transform = selectTeamObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        temp_transform = setScoreOverlay.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        temp_transform = qaGameHostObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, 0f, temp_transform.position.z);
        temp_transform = wagerObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, 0f, temp_transform.position.z);        jeopardyObject.SetActive(true);        doubleJeopardyObject.SetActive(false);        finalJeopardyObject.SetActive(false);        setScoreOverlay.SetActive(false);        qaGameHostObject.SetActive(false);        wagerObject.SetActive(false);

        redTeam = new string[] { "Debuggers", "red1", "red2", "red3", "red4", "red5", "red6", "red7", "red8", "red9" };        blueTeam = new string[] { "Polymorphers", "blue1", "blue2", "blue3", "blue4", "blue5", "blue6", "blue7", "blue8", "blue9" };        for (int i = 0; i < 10; i++)        {            string redButtonName = "RedTeamButton" + i.ToString();            Text redButtonText = GameObject.Find(redButtonName).GetComponentInChildren<Text>();            redButtonText.text = redTeam[i];            string blueButtonName = "BlueTeamButton" + i.ToString();            Text blueButtonText = GameObject.Find(blueButtonName).GetComponentInChildren<Text>();            blueButtonText.text = blueTeam[i];            if(i == 0)            {                changeTeamButtonColor(GameObject.Find(redButtonName), Color.black, Color.white);
                changeTeamButtonColor(GameObject.Find(blueButtonName), Color.black, Color.white);                currentRedIndex = i;                currentBlueIndex = i;            }        }        currentRedScore = 10000;        currentBlueScore = 10000;        selectTeamObject.SetActive(false);    }    private void changeTeamName()    {
        GameObject.Find("HostTeam1Text").GetComponent<Text>().text = redTeam[currentRedIndex];        GameObject.Find("HostTeam2Text").GetComponent<Text>().text = blueTeam[currentBlueIndex];
        audienceObject.SendMessage("changeRedTeamName", redTeam[currentRedIndex]);
        audienceObject.SendMessage("changeBlueTeamName", blueTeam[currentBlueIndex]);    }

    // Update is called once per frame
<<<<<<< HEAD
    void Update () {   	}    //Game host screen event     private void ChangeButtonColorAndText(Button button, Color buttonColor, Color textColor)    {        ColorBlock cb = button.GetComponentInChildren<Button>().colors;        cb.normalColor = cb.highlightedColor = buttonColor;        button.GetComponentInChildren<Button>().colors = cb;        button.GetComponentInChildren<Text>().color = textColor;    }    public void JeopardyButtonClick()    {        //ChangeButtonColorAndText(jeopardyButton, Color.black, Color.white);        //ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);        //ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);        jeopardyObject.SetActive(true);        doubleJeopardyObject.SetActive(false);        finalJeopardyObject.SetActive(false);        audienceObject.SendMessage("changePanel", "0");    }    public void DoubleJeopardyClick()    {        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(doubleJeopardyButton, Color.black, Color.white);        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);        jeopardyObject.SetActive(false);        doubleJeopardyObject.SetActive(true);        finalJeopardyObject.SetActive(false);        audienceObject.SendMessage("changePanel", "1");    }    public void FinalJeopardyClick()    {        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(finalJeopardyButton, Color.black, Color.white);        jeopardyObject.SetActive(false);        doubleJeopardyObject.SetActive(false);        finalJeopardyObject.SetActive(true);        audienceObject.SendMessage("changePanel", "2");

        //Add Music        AudioSource finalJeopardyAudio = GetComponent<AudioSource>();        Debug.Log(finalJeopardyAudio);        //finalJeopardyButton.GetComponent<Button>().onClick.RemoveAllListeners();
        //finalJeopardyButton.GetComponent<Button>().onClick.AddListener(delegate () { finalJeopardyAudio.Play(); });
        finalJeopardyAudio.Play();    }

    public void ExitButtonClick()    {        SceneManager.LoadScene("MainMenu");    }    public void RedButtonClick()    {        Transform temp_transform = setScoreOverlay.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);        setScoreOverlay.SetActive(true);        isRed = true;        scoreInput.text = GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text;    }
=======
    void Update () {   	}    //Game host screen event     private void ChangeButtonColorAndText(Button button, Color buttonColor, Color textColor)    {        ColorBlock cb = button.GetComponentInChildren<Button>().colors;        cb.normalColor = cb.highlightedColor = buttonColor;        button.GetComponentInChildren<Button>().colors = cb;        button.GetComponentInChildren<Text>().color = textColor;    }    public void JeopardyButtonClick()    {        ChangeButtonColorAndText(jeopardyButton, Color.black, Color.white);        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);        jeopardyObject.SetActive(true);        doubleJeopardyObject.SetActive(false);        finalJeopardyObject.SetActive(false);        audienceObject.SendMessage("changePanel", "0");    }    public void DoubleJeopardyClick()    {        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(doubleJeopardyButton, Color.black, Color.white);        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);        jeopardyObject.SetActive(false);        doubleJeopardyObject.SetActive(true);        finalJeopardyObject.SetActive(false);        audienceObject.SendMessage("changePanel", "1");    }    public void FinalJeopardyClick()    {        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(finalJeopardyButton, Color.black, Color.white);        jeopardyObject.SetActive(false);        doubleJeopardyObject.SetActive(false);        finalJeopardyObject.SetActive(true);        audienceObject.SendMessage("changePanel", "2");    }    public void ExitButtonClick()    {        SceneManager.LoadScene("MainMenu");    }    public void RedButtonClick()    {        setScoreOverlay.SetActive(true);        isRed = true;        scoreInput.text = GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text;    }
>>>>>>> 0d93c06192713f26b3b48d4628a94181a6dba026

    public void BlueButtonClick()    {        setScoreOverlay.SetActive(true);        isRed = false;

        scoreInput.text = GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text;    }

    public void QuestionButtonClick()    {        GameObject button = EventSystem.current.currentSelectedGameObject;
        currentButtonName = button.name;

        //get score
        string lineIndex = currentButtonName.Substring((currentButtonName.Length) - 2, 1);
        int line = System.Int32.Parse(lineIndex);        redButtonScore = 100 * (line + 1);        blueButtonScore = redButtonScore;
        qaGameHostObject.SetActive(true);
        //set score
        GameObject.Find("RedAddButton").GetComponentInChildren<Text>().text = "+" + redButtonScore.ToString();
        GameObject.Find("RedSubtractButton").GetComponentInChildren<Text>().text = "-" + blueButtonScore.ToString();
        GameObject.Find("BlueAddButton").GetComponentInChildren<Text>().text = "+" + redButtonScore.ToString();        GameObject.Find("BlueSubtractButton").GetComponentInChildren<Text>().text = "-" + blueButtonScore.ToString();

        audienceObject.SendMessage("changePanel", "3"); //audience screen show quesiton
        string index = currentButtonName.Substring(currentButtonName.Length - 2, 2);        audienceObject.SendMessage("dispearButton", index); //audience dispear button
 
        EventSystem.current.currentSelectedGameObject.SetActive(false);    }
    public void NextTeamButtonClick()    {        if(!(currentRedIndex == redTeam.Length - 1))        {            currentRedIndex += 1;        }        else        {            currentRedIndex = 0;        }        if(!(currentBlueIndex == blueTeam.Length - 1))        {            currentBlueIndex += 1;        }        else        {
            currentBlueIndex = 0;        }

        GameObject.Find("HostTeam1Text").GetComponent<Text>().text = redTeam[currentRedIndex];        audienceObject.SendMessage("changeRedTeamName", redTeam[currentRedIndex]);
        GameObject.Find("HostTeam2Text").GetComponent<Text>().text = blueTeam[currentBlueIndex];        audienceObject.SendMessage("changeBlueTeamName", blueTeam[currentBlueIndex]);    }    public void ChooseTeamButtonClick()    {        selectTeamObject.SetActive(true);

        for (int i = 0; i < redTeam.Length; i++)        {
            string buttonName = "RedTeamButton" + i.ToString();
            GameObject button = GameObject.Find(buttonName);            if (i == currentRedIndex)            {                changeTeamButtonColor(button, Color.black, Color.white);            }            else            {                changeTeamButtonColor(button, Color.white, Color.black);            }        }
        temporaryRedIndex = currentRedIndex;

        for(int i = 0; i < blueTeam.Length; i++)        {
            string buttonName = "BlueTeamButton" + i.ToString();
            GameObject button = GameObject.Find(buttonName);            if (i == currentBlueIndex)            {                changeTeamButtonColor(button, Color.black, Color.white);            }            else            {                changeTeamButtonColor(button, Color.white, Color.black);            }        }        temporaryBlueIndex = currentBlueIndex;    }
    //set score screen event

    public void ExitScoreScreenButtonClick()    {
        scoreInput.text = "";        setScoreOverlay.SetActive(false);    }    public void SetScoreButtonClick()    {        string score = scoreInput.text;        if(isRed)        {            GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text = score;            currentRedScore = System.Int32.Parse(score);        }        else        {            GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text = score;
            currentBlueScore = System.Int32.Parse(score);        }        object[] tempStorage = new object[2];        string a;        if(isRed)        {            a = "1";        }else        {            a = "0";        }        tempStorage[0] = a;        tempStorage[1] = score;        audienceObject.SendMessage("setScore", tempStorage);        setScoreOverlay.SetActive(false);    }    //teacher question pannel    public void ExitQAHostButtonClick()    {        qaGameHostObject.SetActive(false);        audienceObject.SendMessage("changePanel", "4");    }    public void StartButtonClick()    {        TotalTime = 60;        StartCoroutine(CountDown());    }    IEnumerator CountDown()    {
        while (TotalTime >= 0)        {            GameObject.Find("ClockText").GetComponent<Text>().text = TotalTime.ToString();            audienceObject.SendMessage("SetAudienceTime", TotalTime.ToString());            yield return new WaitForSeconds(1);            TotalTime--;        }    }    public void RedAddScoreButtonClick()    {        currentRedScore += redButtonScore;
        GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text = currentRedScore.ToString();
        //currentRedScore = System.Int32.Parse(score);
        object[] tempStorage = new object[2];
        tempStorage[0] = "1"; //1 is means red, 0 is blue        tempStorage[1] = currentRedScore.ToString();        audienceObject.SendMessage("setScore", tempStorage);    }    public void RedSubtractButtonClick()    {
        currentRedScore -= redButtonScore;        GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text = currentRedScore.ToString();
        //currentRedScore = System.Int32.Parse(score);

        object[] tempStorage = new object[2];        tempStorage[0] = "1"; //1 is means red, 0 is blue
        tempStorage[1] = currentRedScore.ToString();        audienceObject.SendMessage("setScore", tempStorage);    }

    public void BlueAddScoreButtonClick()    {        currentBlueScore += blueButtonScore;        GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text = currentBlueScore.ToString();
        //currentRedScore = System.Int32.Parse(score);

        object[] tempStorage = new object[2];        tempStorage[0] = "0"; //1 is means red, 0 is blue
        tempStorage[1] = currentBlueScore.ToString();        audienceObject.SendMessage("setScore", tempStorage);    }    public void BlueSubtractButtonClick()    {        currentBlueScore -= blueButtonScore;        GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text = currentBlueScore.ToString();
        //currentRedScore = System.Int32.Parse(score);

        object[] tempStorage = new object[2];        tempStorage[0] = "0"; //1 is means red, 0 is blue
        tempStorage[1] = currentBlueScore.ToString();        audienceObject.SendMessage("setScore", tempStorage);    }        public void RedWagerButtonClick()    {        isRed = true;        ShowWagerScreen();    }    public void BlueWagerButtonClick()    {        isRed = false;
        ShowWagerScreen();    }    private void ShowWagerScreen()    {        wagerObject.SetActive(true);    }

    //wager pannel

    public void ExitWagerButtonClick()    {
        wagerObject.SetActive(false);    }    public void SetWagerButtonClick()    {        InputField wagerField = wagerObject.GetComponentInChildren<InputField>();

        if (isRed)        { 
            redButtonScore = System.Int32.Parse(wagerField.text);//set score
            GameObject.Find("RedAddButton").GetComponentInChildren<Text>().text = "+" + redButtonScore.ToString();
            GameObject.Find("RedSubtractButton").GetComponentInChildren<Text>().text = "-" + redButtonScore.ToString();        }        else        {
            blueButtonScore = System.Int32.Parse(wagerField.text);//set score
            GameObject.Find("BlueAddButton").GetComponentInChildren<Text>().text = "+" + blueButtonScore.ToString();            GameObject.Find("BlueSubtractButton").GetComponentInChildren<Text>().text = "-" + blueButtonScore.ToString();        }

        wagerField.text = "";
        wagerObject.SetActive(false);    }


    //team pannel

    public void saveTeamButtonClick()    {        if(temporaryRedIndex != currentRedIndex)        {            currentRedIndex = temporaryRedIndex;
            GameObject.Find("HostTeam1Text").GetComponent<Text>().text = redTeam[currentRedIndex];            audienceObject.SendMessage("changeRedTeamName", redTeam[currentRedIndex]);        }        if (temporaryBlueIndex != currentBlueIndex)        {            currentBlueIndex = temporaryBlueIndex;
            GameObject.Find("HostTeam2Text").GetComponent<Text>().text = blueTeam[currentBlueIndex];
            audienceObject.SendMessage("changeBlueTeamName", blueTeam[currentBlueIndex]);        }

        selectTeamObject.SetActive(false);    }    public void ExitTeamButtonClick()    {        selectTeamObject.SetActive(false);    }    public void SelectOneRedTeamButtonClick()    {
        currentButtonName = EventSystem.current.currentSelectedGameObject.name;        string indexString = currentButtonName.Substring((currentButtonName.Length) - 1, 1);        temporaryRedIndex = System.Int32.Parse(indexString);
        for (int i = 0; i < redTeam.Length; i++)
        {
            if (i == temporaryRedIndex)
            {
                GameObject button = EventSystem.current.currentSelectedGameObject;
                changeTeamButtonColor(button, Color.black, Color.white);
            }
            else
            {
                string buttonName = "RedTeamButton" + i.ToString();
                GameObject button = GameObject.Find(buttonName);
                changeTeamButtonColor(button, Color.white, Color.black);
            }
        }    }    public void SelectOneBlueTeamButtonClick()    {
        currentButtonName = EventSystem.current.currentSelectedGameObject.name;        string indexString = currentButtonName.Substring((currentButtonName.Length) - 1, 1);        temporaryBlueIndex = System.Int32.Parse(indexString);        for (int i = 0; i < blueTeam.Length; i++)        {            if (i == temporaryBlueIndex)            {                GameObject button = EventSystem.current.currentSelectedGameObject;                changeTeamButtonColor(button, Color.black, Color.white);            }            else            {                string buttonName = "BlueTeamButton" + i.ToString();                GameObject button = GameObject.Find(buttonName);                changeTeamButtonColor(button, Color.white, Color.black);            }        }    }    private void changeTeamButtonColor(GameObject button, Color buttonColor, Color textColor)
    {
        ColorBlock cb = button.GetComponentInChildren<Button>().colors;        cb.normalColor = cb.highlightedColor = buttonColor;        button.GetComponentInChildren<Button>().colors = cb;        button.GetComponentInChildren<Text>().color = textColor;
    }}