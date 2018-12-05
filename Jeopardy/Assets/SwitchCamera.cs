using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera hostCamera;
    public Camera audienceCamera;

	void Update ()
    {
		if (Input.GetKeyDown("s"))
        {
            var temp = hostCamera.targetDisplay;
            hostCamera.targetDisplay = audienceCamera.targetDisplay;
            audienceCamera.targetDisplay = temp;
        }
	}
}
