using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_PlayerUpState : WJ_PlayerMineState
{
    public WJ_PlayerUpState(WJ_Player _player, WJ_PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rbody.velocity = new Vector2(rbody.velocity.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();
        stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
    }

}
