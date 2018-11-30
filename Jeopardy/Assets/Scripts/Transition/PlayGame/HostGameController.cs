using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.UI;using UnityEngine.SceneManagement;using UnityEngine.EventSystems;using Model;public class HostGameController : MonoBehaviour {    //question panel    private GameObject jeopardyObject;    private GameObject doubleJeopardyObject;    private GameObject finalJeopardyObject;    //set teamscore panel     private GameObject setScoreOverlay;    //select team panel    private GameObject selectTeamObject;    //the question detail of teacher    private GameObject qaGameHostObject;    //set wager panel    private GameObject wagerObject;    //audience panel     send message to the object    private GameObject audienceObject;    //load game panel    private GameObject loadGameObject;    private InputField scoreInput;    public Button jeopardyButton;    public Button doubleJeopardyButton;    public Button finalJeopardyButton;    private string currentButtonName;    private string[] category;    //private int TotalTime; //Countdown    private bool isRed; //change team score and change team wager    private List<string> redTeam;    private List<string> blueTeam;    private int jeoDailyDouble = 1;    private int douDailyDouble = 1;    // Use this for initialization    void Start()    {        //music         FindObjectOfType<AudioManager>().Play("LoadMusic");        jeopardyObject = GameObject.Find("JeopardyPanel");        doubleJeopardyObject = GameObject.Find("DoubleJeopardyPanel");        finalJeopardyObject = GameObject.Find("FinalJeopardyPanel");        setScoreOverlay = GameObject.Find("SetScoreOverlay");        selectTeamObject = GameObject.Find("ChooseTeamsOverlay");        audienceObject = GameObject.Find("GameAudienceScreen");        qaGameHostObject = GameObject.Find("QAGameHostScreen");        wagerObject = GameObject.Find("SetWagerOverlay");        loadGameObject = GameObject.Find("LoadGameOverlay");        scoreInput = setScoreOverlay.GetComponentInChildren<InputField>();        Transform temp_transform = jeopardyObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);        temp_transform = doubleJeopardyObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);        temp_transform = finalJeopardyObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);        temp_transform = setScoreOverlay.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);        temp_transform = selectTeamObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);        temp_transform = qaGameHostObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, 0f, temp_transform.position.z);        temp_transform = wagerObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, 0f, temp_transform.position.z);        temp_transform = loadGameObject.GetComponent<Transform>();        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        ShowAllInformation();

        jeopardyObject.SetActive(true);        doubleJeopardyObject.SetActive(false);        finalJeopardyObject.SetActive(false);        setScoreOverlay.SetActive(false);        qaGameHostObject.SetActive(false);        loadGameObject.SetActive(true);        wagerObject.SetActive(false);
        selectTeamObject.SetActive(false);        StartCoroutine(UpdateAudienceScreen());    }    private void ShowAllInformation()    {        GameDataManager.InitDemo();
        redTeam = GameData.RedTeam;        blueTeam = GameData.BlueTeam;
        AudienceData.GetInstance().SetTeamInformation(GameData.RedTeam, GameData.BlueTeam);        AudienceData.GetInstance().SetTeamsIndex(0, 0);        AudienceData.GetInstance().SetTeamsScore(10000, 10000);        int count = GameData.Category.Count;        for (int i = 0; i < count; i++)        {
            GameObject.Find("Category" + i.ToString()).GetComponentInChildren<Text>().text = GameData.Category[i].Category;
        }        count = GameData.DoubleCategory.Count;
        for (int i = 0; i < count; i++)        {            GameObject.Find("CategoryD" + i.ToString()).GetComponentInChildren<Text>().text = GameData.DoubleCategory[i].Category;        }        GameObject.Find("CategoryF0").GetComponentInChildren<Text>().text = GameData.FinalCategory.Category;    }

    IEnumerator UpdateAudienceScreen()    {        yield return new WaitForSeconds(1);
        UpdateTeamName();        UpdateTeamScore();    }


    // Update is called once per frame
    void Update() {	}    public void ExitButtonClick()    {        SceneManager.LoadScene("MainMenu");    }    //Game host screen event     private void ChangeButtonColorAndText(Button button, Color buttonColor, Color textColor)    {        ColorBlock cb = button.GetComponentInChildren<Button>().colors;        cb.normalColor = cb.highlightedColor = buttonColor;        button.GetComponentInChildren<Button>().colors = cb;        button.GetComponentInChildren<Text>().color = textColor;    }    public void JeopardyButtonClick()    {        ChangeButtonColorAndText(jeopardyButton, Color.black, Color.white);        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);        jeopardyObject.SetActive(true);        doubleJeopardyObject.SetActive(false);        finalJeopardyObject.SetActive(false);        audienceObject.SendMessage("changePanel", "Jeoparydy");    }    public void DoubleJeopardyClick()    {        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(doubleJeopardyButton, Color.black, Color.white);        ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);        jeopardyObject.SetActive(false);        doubleJeopardyObject.SetActive(true);        finalJeopardyObject.SetActive(false);        audienceObject.SendMessage("changePanel", "DoubleJeopardy");    }    public void FinalJeopardyClick()    {        ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);        ChangeButtonColorAndText(finalJeopardyButton, Color.black, Color.white);        jeopardyObject.SetActive(false);        doubleJeopardyObject.SetActive(false);        finalJeopardyObject.SetActive(true);        audienceObject.SendMessage("changePanel", "FinalJeopardy");        //Add Music        AudioSource finalJeopardyAudio = GetComponent<AudioSource>();        Debug.Log(finalJeopardyAudio);        //finalJeopardyButton.GetComponent<Button>().onClick.RemoveAllListeners();        //finalJeopardyButton.GetComponent<Button>().onClick.AddListener(delegate () { finalJeopardyAudio.Play(); });    }    public void RedButtonClick()    {        setScoreOverlay.SetActive(true);        isRed = true;        scoreInput.text = GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text;    }    public void BlueButtonClick()    {        setScoreOverlay.SetActive(true);        isRed = false;        scoreInput.text = GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text;    }    public void QuestionButtonClick()    {        GameObject button = EventSystem.current.currentSelectedGameObject;        currentButtonName = button.name;        //get which button        string lineIndex = currentButtonName.Substring((currentButtonName.Length) - 2, 1);        int line = System.Int32.Parse(lineIndex);
        string rowIndex = currentButtonName.Substring((currentButtonName.Length) - 1, 1);        int row = System.Int32.Parse(lineIndex);        int baseScore;        string index;        int questionType;        if(currentButtonName[6] == 'D')        {            baseScore = 400;            index = currentButtonName.Substring(currentButtonName.Length - 3, 3);            questionType = 1;        }        else if(currentButtonName[6] == 'F')        {            baseScore = 5000;            index = "";            questionType = 2;        }        else        {            baseScore = 100;            index = currentButtonName.Substring(currentButtonName.Length - 2, 2);            questionType = 0;        }        int addButtonScore = baseScore * (line + 1);        if(questionType == 0 && jeoDailyDouble == 1)        {            jeoDailyDouble = 0;            audienceObject.SendMessage("changePanel", "DailyDouble");            return;        }        if(questionType == 1 && douDailyDouble == 1)        {            douDailyDouble = 0;            audienceObject.SendMessage("changePanel", "DailyDouble");            return;        }        AudienceData.GetInstance().SetQuestion(questionType, line, row);        AudienceData.GetInstance().SetAddRedScore(addButtonScore);
        AudienceData.GetInstance().SetAddBlueScore(addButtonScore);        qaGameHostObject.SetActive(true);        audienceObject.SendMessage("changePanel", "Question"); //audience screen show quesiton        // audience button disppears        if (index != "")        {            audienceObject.SendMessage("dispearButton", index);            EventSystem.current.currentSelectedGameObject.SetActive(false);        }    }    //team     public void NextTeamButtonClick()    {        int currentRedIndex = AudienceData.GetInstance().GetCurrentRedIndex();        int currentBlueIndex = AudienceData.GetInstance().GetCurrentBlueIndex();        if(!(currentRedIndex == redTeam.Count - 1))        {            currentRedIndex += 1;        }        else        {            currentRedIndex = 0;        }        if(!(currentBlueIndex == blueTeam.Count - 1))        {            currentBlueIndex += 1;        }        else        {            currentBlueIndex = 0;        }        AudienceData.GetInstance().SetTeamsIndex(currentRedIndex, currentBlueIndex);        UpdateTeamName();    }    public void ChooseTeamButtonClick()    {        selectTeamObject.SetActive(true);    }    //set score screen event    public void SetScoreButtonClick()    {        string score = scoreInput.text;                if (isRed)        {            int currentRedScore = System.Int32.Parse(score);            AudienceData.GetInstance().SetRedTeamScore(currentRedScore);
        }        else        {            int currentBlueScore = System.Int32.Parse(score);
            AudienceData.GetInstance().SetBlueTeamScore(currentBlueScore);        }        UpdateTeamScore();        setScoreOverlay.SetActive(false);    }

    public void ExitScoreScreenButtonClick()    {        scoreInput.text = "";        setScoreOverlay.SetActive(false);    }    public void UpdateTeamScore()    {
        GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text = AudienceData.GetInstance().GetRedScore().ToString();
        GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text = AudienceData.GetInstance().GetBlueScore().ToString();
        NotifyAudience();    }    public void UpdateTeamName()    {        //Debug.Log(GameObject.Find("HostTeam1Text").GetComponent<Text>().text);        GameObject.Find("HostTeam1Text").GetComponent<Text>().text = redTeam[AudienceData.GetInstance().GetCurrentRedIndex()];        GameObject.Find("HostTeam2Text").GetComponent<Text>().text = blueTeam[AudienceData.GetInstance().GetCurrentBlueIndex()];        NotifyAudience();    }    public void NotifyAudience()    {        audienceObject.SendMessage("UpdateAudienceData");    }}