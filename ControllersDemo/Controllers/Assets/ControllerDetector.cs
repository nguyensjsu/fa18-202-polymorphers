using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDetector : MonoBehaviour
{
    public Text controller1text;
    public Text controller2text;

    public string[] names;

    void Start()
    {
        Search();
    }

    public void Update()
    {
        if (Input.GetButton("Buzz_Button_1"))
        {
            print("buzz 1");
        }

        if (Input.GetButton("Buzz_Button_2"))
        {
            print("buzz 2");
        }
    }

    public void Search()
    {
        names = Input.GetJoystickNames();

        if (names.Length == 0)
        {
            controller1text.text = "Controller1: ";
            controller2text.text = "Controller2: ";
        }
        else if (names.Length == 1)
        {
            controller1text.text = "Controller1: " + Input.GetJoystickNames()[0];
            controller2text.text = "Controller2: ";

        }
        else
        {
            controller1text.text = "Controller1: ";
            controller2text.text = "Controller2: " + Input.GetJoystickNames()[1];
        }

    }
}
