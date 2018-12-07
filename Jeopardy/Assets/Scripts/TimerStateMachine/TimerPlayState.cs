using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPlayState : MonoBehaviour, IState
{
    TimerFSM fsm;
    //string nowstate = "play";

    public TimerPlayState(TimerFSM fsm)
    {
        this.fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("enter play state");
        fsm.AudienceObject.SendMessage("changePanel", "Question"); //audience screen show quesiton
        fsm.aibuzzin.enableBuzzes();
    }

    public void OnPause()
    {
        fsm.aibuzzin.disableBuzzes();
        fsm.setState(fsm.getTimerPauseState());
    }

    public void OnReset()
    {
        fsm.TotalTime = 60;
        fsm.UpdateClockText();
        fsm.setState(fsm.getTimerPauseState());
    }

    public void OnStart()
    {
    }

    public void OnUpdate()
    {
    }
   
}
