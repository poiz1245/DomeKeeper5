using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_PlayerStateMachine
{
    public WJ_PlayerState currentState { get; private set; }
    public void Initialize(WJ_PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(WJ_PlayerState _newState)   //���� ���� �޼���
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

}
