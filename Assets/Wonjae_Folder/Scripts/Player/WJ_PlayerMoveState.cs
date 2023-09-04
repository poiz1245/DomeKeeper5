using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_PlayerMoveState : WJ_PlayerState
{
    public WJ_PlayerMoveState(WJ_Player _player, WJ_PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.xInput * player.Speed, rbody.velocity.y);

        if (player.xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }

   
}
