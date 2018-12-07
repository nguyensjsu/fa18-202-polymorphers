using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerFSM : MonoBehaviour
{
    public AIBuzzIn aibuzzin;
    public int TotalTime { get; set; } //Countdown
    public GameObject AudienceObject { get; private set; }

    private Text clockText;

    public GameObject startButton;
    public GameObject pauseButton;
    public GameObject resetButton;


    IState timerPlayState;
    IState timerPauseState;

    IState state;

    // Use this for initialization
    void Start()
    {
        timerPlayState = new TimerPlayState(this);
        timerPauseState = new TimerPauseState(this);
        setState(timerPauseState);

        AudienceObject = GameObject.Find("GameAudienceScreen");
        clockText = GameObject.Find("ClockText").GetComponent<Text>();
    }

    void Update()
    {
    }

    public TimerFSM()
    {

    }

    public void setState(IState newstate)
    {
        Debug.Log("newstate: " + newstate);
        this.state = newstate;

        this.state.OnEnter();
    }

    public IState getState()
    {
        return state;
    }

    public IState getTimerPauseState()
    {
        return timerPauseState;
    }

    public IState getTimerPlayState()
    {
        Debug.Log("getTimerPlayState:" + timerPlayState);
        return timerPlayState;
    }

    public void PauseButtonClick()
    {
        state.OnPause();
    }

    public void StartButtonClick()
    {
        state.OnStart();
    }

    public void ResetButtonClick()
    {
        state.OnReset();
    }

    public void StartCountDown()
    {
        StartCoroutine("ICountDown");
    }

    public void PauseCountDown()
    {
        StopCoroutine("ICountDown");
    }

    private IEnumerator ICountDown()
    {

        while (TotalTime >= 0)
        {
            UpdateClockText();
            yield return new WaitForSeconds(1);
            TotalTime--;
        }
    }

    public void UpdateClockText()
    {
        clockText.text = TotalTime.ToString();
        AudienceObject.SendMessage("SetAudienceTime", TotalTime.ToString());
    }
}

