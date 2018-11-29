using UnityEngine;
using UnityEngine.UI;

public class CreateGameTabsPanel : MonoBehaviour
{
    //public Button teamsButton;
    //public Button jeopardyButton;
    //public Button doubleJeopardyButton;
    //public Button finalJeopardyButton;

    //private GameObject teamsObject;
    //private GameObject jeopardyObject;
    //private GameObject doubleJeopardyObject;
    //private GameObject finalJeopardyObject;

    //public CreateGameController cgc;

    //// Use this for initialization
    //void Start ()
    //{
    //    teamsObject = GameObject.Find("TeamsPanel").GetComponent<Button>();
    //    jeopardyObject = GameObject.Find("JeopardyPanel");
    //    doubleJeopardyObject = GameObject.Find("DoubleJeopardyPanel");
    //    finalJeopardyObject = GameObject.Find("FinalJeopardyPanel");

    //    Transform temp_transform = jeopardyObject.GetComponent<Transform>();
    //    temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
    //    temp_transform = finalJeopardyObject.GetComponent<Transform>();
    //    temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
    //    temp_transform = doubleJeopardyObject.GetComponent<Transform>();
    //    temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

    //    teamsObject.SetActive(true);
    //    jeopardyObject.SetActive(false);
    //    doubleJeopardyObject.SetActive(false);
    //    finalJeopardyObject.SetActive(false);
    //}

    //private void ChangeButtonColorAndText(Button button, Color buttonColor, Color textColor)
    //{
    //    ColorBlock cb = button.GetComponentInChildren<Button>().colors;
    //    cb.normalColor = cb.highlightedColor = buttonColor;
    //    button.GetComponentInChildren<Button>().colors = cb;
    //    button.GetComponentInChildren<Text>().color = textColor;
    //}

    //public void TeamsButtonClick()
    //{
    //    ChangeButtonColorAndText(teamsButton, Color.black, Color.white);
    //    ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);
    //    ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);
    //    ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);

    //    teamsObject.SetActive(true);
    //    jeopardyObject.SetActive(false);
    //    doubleJeopardyObject.SetActive(false);
    //    finalJeopardyObject.SetActive(false);
    //}

    //public void JeopardyButtonClick()
    //{
    //    ChangeButtonColorAndText(teamsButton, Color.white, Color.black);
    //    ChangeButtonColorAndText(jeopardyButton, Color.black, Color.white);
    //    ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);
    //    ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);

    //    teamsObject.SetActive(false);
    //    jeopardyObject.SetActive(true);
    //    doubleJeopardyObject.SetActive(false);
    //    finalJeopardyObject.SetActive(false);
    //}

    //public void DoubleJeopardyClick()
    //{
    //    ChangeButtonColorAndText(teamsButton, Color.white, Color.black);
    //    ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);
    //    ChangeButtonColorAndText(doubleJeopardyButton, Color.black, Color.white);
    //    ChangeButtonColorAndText(finalJeopardyButton, Color.white, Color.black);

    //    teamsObject.SetActive(false);
    //    jeopardyObject.SetActive(false);
    //    doubleJeopardyObject.SetActive(true);
    //    finalJeopardyObject.SetActive(false);
    //}

    //public void FinalJeopardyClick()
    //{
    //    ChangeButtonColorAndText(teamsButton, Color.white, Color.black);
    //    ChangeButtonColorAndText(jeopardyButton, Color.white, Color.black);
    //    ChangeButtonColorAndText(doubleJeopardyButton, Color.white, Color.black);
    //    ChangeButtonColorAndText(finalJeopardyButton, Color.black, Color.white);

    //    teamsObject.SetActive(false);
    //    jeopardyObject.SetActive(false);
    //    doubleJeopardyObject.SetActive(false);
    //    finalJeopardyObject.SetActive(true);

    //    Transform temp_transform = finalJeopardyObject.GetComponent<Transform>();
    //    temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

    //}
}
