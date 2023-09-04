using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class WJ_PlayerDigState : WJ_PlayerState
{
    public WJ_PlayerDigState(WJ_Player _player, WJ_PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.drill.SetActive(true);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.xInput * player.Speed, rbody.velocity.y);


        if (mousePosition.x > player.transform.position.x)
        {
            spriteRender.flipX = true;
        }
        else
        {
            spriteRender.flipY = false;
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.drill.SetActive(false);
    }

}
