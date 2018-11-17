using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameController : MonoBehaviour {

    private GameObject jeopardyObject;
    private GameObject doubleJeopardyObject;
    private GameObject finalJeopardyObject;
    private Transform temp_transform;

    // Use this for initialization
    void Start () {

        jeopardyObject = GameObject.Find("JeopardyPanel");
        doubleJeopardyObject = GameObject.Find("DoubleJeopardyPanel");
        finalJeopardyObject = GameObject.Find("FinalJeopardyPanel");

        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void JeopardyButtonClick(){
        jeopardyObject.SetActive(true);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(false);
    }

    public void DoubleJeopardyClick(){
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(true);
        finalJeopardyObject.SetActive(false);


        temp_transform = doubleJeopardyObject.GetComponent<Transform>();
        //temp_transform.Translate(0f, temp_transform.position.y, temp_transform.position.z);
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);
    }

    public void FinalJeopardyClick(){
        jeopardyObject.SetActive(false);
        doubleJeopardyObject.SetActive(false);
        finalJeopardyObject.SetActive(true);
    }

    public void OneHunderdButtonClick(){

    }
}
