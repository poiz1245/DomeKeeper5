using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_PlayerDownState : WJ_PlayerMineState
{
    public WJ_PlayerDownState(WJ_Player _player, WJ_PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(rbody.velocity.x, player.yInput * player.Speed);

        if (player.yInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
