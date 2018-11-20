using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HostGameController : MonoBehaviour {

    private GameObject jeopardyObject;
    private GameObject doubleJeopardyObject;
    private GameObject finalJeopardyObject;

    private GameObject setScoreOverlay;
    private InputField scoreInput;

    private bool isRed;

    // Use this for initialization
    void Start()
    {
        jeopardyObject = GameObject.Find("JeopardyPanel");
        doubleJeopardyObject = GameObject.Find("DoubleJeopardyPanel");
        finalJeopardyObject = GameObject.Find("FinalJeopardyPanel");

        setScoreOverlay = GameObject.Find("SetScoreOverlay");
        scoreInput = GameObject.Find("SetScoreOverlay").GetComponentInChildren<InputField>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void JeopardyButtonClick()
    {
        Debug.Log("123");


        jeopardyObject.SetActive(true);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
    }

    public void DoubleJeopardyClick()
    {

        Debug.Log("123");
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(true);
        finalJeopardyObject.SetActive(false);


        Transform temp_transform = doubleJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
    }

    public void FinalJeopardyClick()
    {

        Debug.Log("123");

        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(true);

        Transform temp_transform = finalJeopardyObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

    }

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void RedButtonClick()
    {
        Transform temp_transform = setScoreOverlay.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        setScoreOverlay.SetActive(true);
        isRed = true;

    }

    public void ExitScoreScreenButtonClick()
    {
        setScoreOverlay.SetActive(false);
    }

    public void SetScoreButtonClick()
    {
        string score = scoreInput.text;
        if(isRed)
        {
            GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text = score;
        }
        else
        {
            GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text = score;
        }
        setScoreOverlay.SetActive(false);

    }

    public void BlueButtonClick()
    {
        Transform temp_transform = setScoreOverlay.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
        setScoreOverlay.SetActive(true);
        isRed = false;
    }


}
