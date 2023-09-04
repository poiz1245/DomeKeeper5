using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_PlayerState
{
    protected WJ_PlayerStateMachine stateMachine;
    protected WJ_Player player;

    public Vector3 mousePosition;
    protected Rigidbody2D rbody;
    protected SpriteRenderer spriteRender;

    private string animBoolName;


    public WJ_PlayerState(WJ_Player _player, WJ_PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rbody = player.rbody;
        spriteRender = player.spriteRender;
    }
    public virtual void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //player.anim.SetFloat("yVelocity", rbody.velocity.y);

    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
}
