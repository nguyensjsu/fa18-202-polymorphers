using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateGamePanelSwitch : MonoBehaviour
{
    private string[] panelList =
    {
        "Teams", "Jeopardy", "DoubleJeopardy", "FinalJeopardy" 
    };

    private string[] gamePanelList =
    {
        "CategoryEdit", "QuestionEdit", "NewGameOrLoadGame", "LoadGame"
    };
    
    private Dictionary<string, GameObject> panels;
    private Dictionary<string, Button> panelButton;
    private Dictionary<string, GameObject> gamePanels;

    public GameObject GameButtonPrefab;

    void Start()
    {
        panels = new Dictionary<string, GameObject>();
        gamePanels = new Dictionary<string, GameObject>();
        panelButton = new Dictionary<string, Button>();
        foreach (var panelName in panelList)
        {
            GameObject panel = GameObject.Find(panelName+"Panel");
            panels.Add(panelName, panel);
            
            Button button = GameObject.Find(panelName+"Button").GetComponent<Button>();
            panelButton.Add(panelName,button);
            panel.transform.position = new Vector3(-512,-384,0);
            panel.SetActive(false);
        }
        panels["Teams"].SetActive(true);
        foreach (var panelName in gamePanelList)
        {
            GameObject panel = GameObject.Find(panelName+"Panel");
            gamePanels.Add(panelName, panel);
            panel.transform.position = new Vector3(0, -1000, 0);
        }
        OpenPanel("NewGameOrLoadGame");


        GameObject savedGamePanel = GameObject.Find("SavedGamesPanel");
        Debug.Log(savedGamePanel.name);
        FileInfo[] files = GameDataManager.LoadFiles();
        foreach (var file in files) {
            var gameButton = Instantiate(GameButtonPrefab);
            var buttonObj = gameButton.GetComponent<LoadGameButton>();
            buttonObj.file = file;
            gameButton.GetComponent<Button>().onClick.AddListener(() => ClosePanel("LoadGame"));
            gameButton.transform.SetParent(savedGamePanel.transform);
        }
        
        SceneManager.sceneUnloaded += (scene) =>
        {
            Debug.Log(scene.name);
            if (scene.name == "CreateEditGame")
                OpenPanel("NewGameOrLoadGame");
        };
    }

    private void ChangeButtonColorAndText(Button button, Color buttonColor, Color textColor)
    {
        ColorBlock cb = button.GetComponentInChildren<Button>().colors;
        cb.normalColor = cb.highlightedColor = buttonColor;
        button.GetComponentInChildren<Button>().colors = cb;
        button.GetComponentInChildren<Text>().color = textColor;
    }

    private void SetActive(string name)
    {
        foreach (var panel in panelList)
        {
            panels[panel].SetActive(false);
            ChangeButtonColorAndText(panelButton[panel], Color.white, Color.black);
        }
        panels[name].SetActive(true);
        ChangeButtonColorAndText(panelButton[name], Color.white, Color.black);
        
    }
    
    public void SwitchToTeams()
    {  
        SetActive("Teams");
    }

    public void SwitchToJeopardy()
    {
        SetActive("Jeopardy");
    }

    public void SwitchToDoubleJeopardy()
    {
        SetActive("DoubleJeopardy");
    }

    public void SwitchToFinalJeopardy()
    {
        SetActive("FinalJeopardy");
    }

    public void OpenPanel(string name)
    {
        gamePanels[name].transform.position = new Vector3(0,0,0);
    }
    
    public void ClosePanel(string name)
    {
        gamePanels[name].transform.position = new Vector3(0,-1000,0);
    }
}
