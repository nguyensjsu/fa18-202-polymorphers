using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditQuestion : MonoBehaviour
{
    public GameObject editPanel;

    public void OpenQuestionEditPanel()
    {
        // get the text saved in the clicked button's text box
        string answer = EventSystem.current.currentSelectedGameObject.gameObject.transform.Find("AnswerText").GetComponent<Text>().text;

        // activate and pass that text to the editing panel
        editPanel.SetActive(true);
        editPanel.transform.Find("InputField").GetComponent<InputField>().text = answer;

        //pass this button to the edit panel so this button can be updated
        editPanel.GetComponent<CloseQuestionEditPanel>().button = gameObject.GetComponent<Button>();
    }
}
