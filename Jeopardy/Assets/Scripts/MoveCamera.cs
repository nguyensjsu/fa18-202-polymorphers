using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    void Start()
    {

    }
    /* Moves the camera to a world coordinate to "switch" screens
     * @param screen Each screen maps to a world coordinate for the camera
     */
    public void MoveToScreen(string screen)
    {
        if (screen == "professorgame")
        {
            transform.position = new Vector3(2736, 0, 0);
        }
        else if (screen == "creategame")
        {
            transform.position = new Vector3(1368, 0, 0);
        }
        else if (screen == "mainmenu")
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else if (screen == "audiencegame")
        {
            transform.position = new Vector3(2736, 1368, 0);
        }
    }
}
