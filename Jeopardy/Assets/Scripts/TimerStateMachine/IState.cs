using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter();
    void OnReset();
    void OnPause();
    void OnStart();
}

