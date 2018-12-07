using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPauseState : MonoBehaviour, IState
{
    TimerFSM fsm;

    public TimerPauseState(TimerFSM fsm)
    {
        this.fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("entered pause state");
        fsm.PauseCountDown();
        fsm.startButton.SetActive(true);
        fsm.pauseButton.SetActive(false);
        fsm.resetButton.SetActive(true);
    }

    public void OnPause()
    {
    }

    public void OnReset()
    {
        fsm.TotalTime = 60;
        fsm.UpdateClockText();
    }

    public void OnStart()
    {
        fsm.StartCountDown();
        fsm.AudienceObject.SendMessage("changePanel", "Question"); //audience screen show quesiton
        fsm.startButton.SetActive(false);
        fsm.pauseButton.SetActive(true);
        fsm.resetButton.SetActive(false);

        fsm.setState(fsm.getTimerPlayState());
    }
}
