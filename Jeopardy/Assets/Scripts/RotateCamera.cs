using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateCamera : MonoBehaviour {

    public float rotateRate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotateRight() {
        StartCoroutine("IRotateRight");
    }

    IEnumerator IRotateRight() {
        print("rotating...");
        float angle = transform.rotation.y;
        float targetAngle = angle + 90;

        while(angle < targetAngle)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
            angle += rotateRate * Time.deltaTime;
            yield return null;
        }
    }
}
