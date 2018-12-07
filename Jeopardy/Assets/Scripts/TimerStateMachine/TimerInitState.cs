using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerInitState : MonoBehaviour, IState
{
    TimerFSM fsm;

    public TimerInitState(TimerFSM fsm)
    {
        this.fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("Entered Init state");
        fsm.TotalTime = 60;
        fsm.setState(fsm.getTimerPauseState());
    }

    public void OnExit()
    {
    }

    public void OnPause()
    {
    }

    public void OnReset()
    {
    }

    public void OnStart()
    {
    }

    public void OnUpdate()
    {
    }
}

