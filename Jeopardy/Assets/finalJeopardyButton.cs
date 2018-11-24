using UnityEngine.UI;
using UnityEngine;

public class finalJeopardyButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button b = GetComponent<Button>();
        AudioSource finalJeopardyAudio = GetComponent<AudioSource>();
        b.onClick.AddListener(delegate () { finalJeopardyAudio.Play(); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
