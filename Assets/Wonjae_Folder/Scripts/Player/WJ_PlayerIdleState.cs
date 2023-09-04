using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_PlayerIdleState : WJ_PlayerState
{
    public WJ_PlayerIdleState(WJ_Player _player, WJ_PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (player.xInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }

        if(player.yInput != 0)
        {
            stateMachine.ChangeState(player.downState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
